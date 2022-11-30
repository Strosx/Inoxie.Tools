using Inoxie.Tools.AzureSearch.Models;
using Inoxie.Tools.AzureSearch.Options;
using System.Net.Http.Json;

namespace Inoxie.Tools.AzureSearch.Client;

internal class AzureSearchClient<T> : IAzureSearchClient<T> where T : class
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly AzureIndexSearchOptions<T> _options;

    public AzureSearchClient(IHttpClientFactory httpClientFactory, AzureIndexSearchOptions<T> options)
    {
        _httpClientFactory = httpClientFactory;
        _options = options;
    }

    public async Task<ICollection<T>> Search(string search, CancellationToken cancellationToken = default)
    {
        var httpClient = _httpClientFactory.CreateClient(_options.IndexName);
        var response = await httpClient.GetAsync($"{_options.IndexUrl.PathAndQuery}&search={search}", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var message = await response.Content.ReadAsStringAsync(cancellationToken);
            throw new Exception($"Failed to request data from Az search, ex: {message}");
        }

        var content = await response.Content.ReadFromJsonAsync<AzureSearchResponse<T>>(cancellationToken: cancellationToken);

        return content?.Value ?? new List<T>();
    }
}