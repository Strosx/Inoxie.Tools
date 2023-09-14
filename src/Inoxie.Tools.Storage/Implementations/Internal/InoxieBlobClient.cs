using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

namespace Inoxie.Tools.Storage.Implementations.Internal;

/// <summary>
/// Represents a client for interacting with Azure Blob Storage services.
/// This client provides functionalities specific to Inoxie's usage patterns.
/// </summary>
internal class InoxieBlobClient
{
    private readonly BlobServiceClient blobServiceClient;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="InoxieBlobClient"/> class.
    /// </summary>
    /// <param name="configuration">The application configuration to retrieve connection settings.</param>
    public InoxieBlobClient(IConfiguration configuration)
    {
        blobServiceClient = new BlobServiceClient(configuration.GetConnectionString("Storage"));
    }

    /// <summary>
    /// Gets the host name of the Azure Blob Storage service endpoint.
    /// </summary>
    public string Host => blobServiceClient.Uri.Host;
    
    /// <summary>
    /// Retrieves or creates (if it does not exist) a blob container in the Azure Blob Storage.
    /// </summary>
    /// <param name="containerName">The name of the blob container.</param>
    /// <returns>A <see cref="BlobContainerClient"/> that represents the specified blob container.</returns>
    public async Task<BlobContainerClient> GetContainer(string containerName)
    {
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);
        return containerClient;
    }
}