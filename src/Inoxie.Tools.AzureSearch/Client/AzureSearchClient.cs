using Inoxie.Tools.AzureSearch.Models;
using Inoxie.Tools.AzureSearch.Options;
using System.Net.Http.Json;

namespace Inoxie.Tools.AzureSearch.Client;

internal class AzureSearchClient<T> : IAzureSearchClient<T> where T : class, IAzureSearchModel
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly AzureIndexSearchOptions<T> options;

    public AzureSearchClient(IHttpClientFactory httpClientFactory, AzureIndexSearchOptions<T> options)
    {
        this.httpClientFactory = httpClientFactory;
        this.options = options;
    }

    public async Task<ICollection<T>> Search(string search, CancellationToken cancellationToken = default)
    {
        var httpClient = httpClientFactory.CreateClient(options.IndexName);
        var response = await httpClient.GetAsync($"{options.IndexUrl.PathAndQuery}&search={search}", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var message = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new Exception($"Failed to request data from Az search, ex: {message}");
        }

        var content = await response.Content.ReadFromJsonAsync<AzureSearchResponse<T>>(cancellationToken: cancellationToken);

        return content?.Value ?? new List<T>();
    }
}