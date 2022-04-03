using Inoxie.Tools.RedisCache.Abstractions.Interfaces;
using System.Text.Json;

namespace Inoxie.Tools.RedisCache.Services;

internal class RedisCacheRepository<T> : IRedisCacheRepository<T> where T : class, new()
{
    private readonly RedisCacheToolService redisCacheToolService;
    private readonly RedisKeyProvider redisKeyProvider;
    private readonly string baseKey;

    public RedisCacheRepository(
        RedisCacheToolService redisCacheToolService,
        IRedisCacheKeyProvider<T> redisCacheKeyProvider,
        RedisKeyProvider redisKeyProvider)
    {
        this.redisCacheToolService = redisCacheToolService;
        this.redisKeyProvider = redisKeyProvider;
        this.baseKey = redisCacheKeyProvider.BaseKey;
    }

    public Task RemoveAsync(string subKey)
    {
        return redisCacheToolService.RemoveAsync(MergeKeys(baseKey, subKey));
    }

    public async Task<T> GetOrCreateAsync(string subKey, Func<Task<T>> fallback)
    {
        var cacheStringItem = await redisCacheToolService.GetOrSetAsync(MergeKeys(baseKey, subKey), async () =>
        {
            var item = await fallback();
            return JsonSerializer.Serialize(item);
        });

        return JsonSerializer.Deserialize<T>(cacheStringItem);
    }

    private string MergeKeys(string baseKey, string subKey)
    {
        return redisKeyProvider.GetKey(baseKey, subKey);
    }
}
