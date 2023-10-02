using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Inoxie.Tools.Storage.Interfaces;

/// <summary>
/// Defines a contract for performing operations on Blob storage.
/// </summary>
public interface IBlobStorageClient
{
    /// <summary>
    /// Uploads a stream to the Blob storage.
    /// </summary>
    /// <param name="stream">The stream to upload.</param>
    /// <param name="containerName">The container in which to store the blob.</param>
    /// <param name="blobName">The name for the blob. If null, a new GUID will be used as the name.</param>
    /// <param name="contentType">The content type of the blob. Defaults to "application/octet-stream" if not specified.</param>
    /// <param name="metadata">Metadata to be associated with the blob.</param>
    /// <returns>The absolute URI of the uploaded blob.</returns>
    Task<string> UploadAsync(Stream stream, string containerName, string blobName = null, string contentType = null, IDictionary<string, string> metadata = null);
   
    /// <summary>
    /// Downloads a blob from the Blob storage.
    /// </summary>
    /// <param name="downloadUri">The URI of the blob to download.</param>
    /// <returns>A stream containing the blob's data.</returns>
    Task<Stream> DownloadAsync(string downloadUri);
    
    /// <summary>
    /// Retrieves the metadata of a specified blob.
    /// </summary>
    /// <param name="downloadUri">The URI of the blob whose metadata is to be fetched.</param>
    /// <returns>A dictionary containing the blob's metadata.</returns>
    Task<IDictionary<string, string>> GetMetadataAsync(string downloadUri);
    
    /// <summary>
    /// Deletes a specified blob.
    /// </summary>
    /// <param name="downloadUri">The URI of the blob to delete.</param>
    Task DeleteAsync(string downloadUri);
}
