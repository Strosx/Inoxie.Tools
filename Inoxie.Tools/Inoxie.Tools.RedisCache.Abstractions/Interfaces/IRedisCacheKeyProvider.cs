namespace Inoxie.Tools.RedisCache.Abstractions.Interfaces
{
    public interface IRedisCacheKeyProvider<T> where T : class, new()
    {
        string BaseKey { get; }
    }
}
