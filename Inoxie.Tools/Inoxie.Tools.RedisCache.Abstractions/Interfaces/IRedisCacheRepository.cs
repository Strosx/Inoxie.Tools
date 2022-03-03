namespace Inoxie.Tools.RedisCache.Abstractions.Interfaces
{
    public interface IRedisCacheRepository<T> where T : class, new()
    {
        Task<T> GetOrCreateAsync(string subKey, Func<Task<T>> fallback);
        Task RemoveAsync(string subKey);
    }
}
