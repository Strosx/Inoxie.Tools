using System.Text.Json.Serialization;

namespace Inoxie.Tools.Search.Models;

internal class AzureSearchResponse<T> where T : class
{
    [JsonPropertyName("@odata.context")]
    public string Context { get; set; }

    [JsonPropertyName("@odata.nextLink")]
    public string NextLink { get; set; }

    [JsonPropertyName("value")]
    public ICollection<T> Value { get; set; }
}