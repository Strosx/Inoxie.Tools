using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Inoxie.Tools.Storage.Interfaces;

public interface IBlobStorageClient
{
    Task<string> UploadAsync(Stream stream, string containerName, string blobName = null, string contentType = null, IDictionary<string, string> metadata = null);
    Task<Stream> DownloadAsync(string downloadUri);
    Task<IDictionary<string, string>> GetMetadataAsync(string downloadUri);
    Task DeleteAsync(string downloadUri);
}
