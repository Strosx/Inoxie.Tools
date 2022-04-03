using Inoxie.Tools.KeyWarehouse.Client.Configuration;
using Inoxie.Tools.KeyWarehouse.Client.Implementations;
using Inoxie.Tools.KeyWarehouse.Client.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;

namespace Inoxie.Tools.KeyWarehouse.Client.DI;

internal static class KeyWarehouseClientDependencyInjection
{
    public const string KeyWarehouseHttpClientName = "KeyWarehouseHttpClient";

    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<WarehouseClientConfiguration>(options =>
            configuration.GetSection(WarehouseClientConfiguration.Key).Bind(options));

        services.AddHttpClient(KeyWarehouseHttpClientName, (services, http) =>
        {
            var configuration = services.GetService<IOptions<WarehouseClientConfiguration>>();

            if (configuration == null)
            {
                throw new Exception("Configuration is null");
            }

            var username = configuration.Value.Username;
            var password = configuration.Value.Password;
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));

            http.BaseAddress = new Uri(configuration.Value.BaseAddress);
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
        });

        services.AddScoped<IWarehouseKeysReadClient, WarehouseKeysReadClient>();
        services.AddScoped<IWarehouseKeysWriteClient, WarehouseKeysWriteClient>();
        services.AddScoped<IWarehouseProductsWriteClient, WarehouseProductsWriteClient>();
    }
}

public static class KeyWarehouseClientDependencyInjectionExtions
{
    public static void AddKeyWarehouseClient(this IServiceCollection services, IConfiguration configuration)
    {
        KeyWarehouseClientDependencyInjection.Register(services, configuration);
    }
}
