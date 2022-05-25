using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

namespace Inoxie.Tools.Storage.Implementations.Internal;

internal class InoxieBlobClient
{
    private readonly BlobServiceClient blobServiceClient;

    public InoxieBlobClient(IConfiguration configuration)
    {
        blobServiceClient = new BlobServiceClient(configuration.GetConnectionString("Storage"));
    }

    public string Host => blobServiceClient.Uri.Host;

    public async Task<BlobContainerClient> GetContainer(string containerName)
    {
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);
        return containerClient;
    }
}