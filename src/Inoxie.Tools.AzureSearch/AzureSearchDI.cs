using Inoxie.Tools.AzureSearch.Client;
using Inoxie.Tools.AzureSearch.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Inoxie.Tools.AzureSearch;

public static class AzureSearchDI
{
    public static IServiceCollection InstallAzureSearch(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AzureSearchConfig>(options => configuration.GetSection("AzureSearchConfig").Bind(options));

        return services;
    }

    public static IServiceCollection AddAzureSearchIndex<T>(this IServiceCollection services, string indexName)
        where T : class
    {
        var searchConfig = services.BuildServiceProvider().GetService<IOptions<AzureSearchConfig>>();

        if (searchConfig is null)
            throw new Exception("Install Azure Search config at first.");

        var index = searchConfig.Value.Indexes.FirstOrDefault(x => x.Name == indexName);

        if (index is null)
            throw new Exception($"Couldn't find config for provided index name: {indexName}.");

        var indexConfig = new AzureIndexSearchOptions<T>
        {
            IndexName = index.Name,
            IndexUrl = new Uri(index.IndexUrl),
        };

        services
            .AddSingleton(indexConfig)
            .AddHttpClient(indexConfig.IndexName, (http) =>
            {
                http.BaseAddress = indexConfig.IndexUrl;
                http.DefaultRequestHeaders.TryAddWithoutValidation("api-key", searchConfig.Value.ApiKey);
            });

        services.AddScoped<IAzureSearchClient<T>, AzureSearchClient<T>>();

        return services;
    }
}