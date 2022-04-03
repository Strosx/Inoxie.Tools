using Inoxie.Tools.RedisCache.Abstractions.Interfaces;
using Inoxie.Tools.RedisCache.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inoxie.Tools.RedisCache.DI;

internal class RediesCacheToolDependencyInjection
{
    public static void Configure(IServiceCollection services, IConfiguration configuration, string databaseName = null)
    {
        services.AddScoped(typeof(IRedisCacheRepository<>), typeof(RedisCacheRepository<>));
        services.AddScoped<RedisCacheToolService>();
        services.AddScoped(s => new RedisKeyProvider(databaseName));
        services.AddSingleton(s => RedisConnection.InitializeAsync(connectionString: configuration.GetConnectionString("Redis")));
    }
}

public static class RedisCacheToolExtensions
{
    public static void AddInoxieToolsRedisCache(this IServiceCollection services, IConfiguration configuration, string databaseName = null)
    {
        RediesCacheToolDependencyInjection.Configure(services, configuration, databaseName);
    }
}
