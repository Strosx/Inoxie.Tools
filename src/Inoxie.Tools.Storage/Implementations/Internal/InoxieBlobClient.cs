using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

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
        var existingContainer = blobServiceClient.GetBlobContainerClient(containerName);

        if (existingContainer == null)
        {
            var response = await blobServiceClient.CreateBlobContainerAsync(containerName);
            return response.Value;
        }

        return await Task.FromResult(existingContainer);
    }
}