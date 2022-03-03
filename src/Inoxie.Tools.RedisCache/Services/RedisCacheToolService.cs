using System;
using System.Threading.Tasks;

namespace Inoxie.Tools.RedisCache.Services
{
    internal class RedisCacheToolService
    {
        private readonly Task<RedisConnection> redisConnection;

        public RedisCacheToolService(Task<RedisConnection> redisConnection)
        {
            this.redisConnection = redisConnection;
        }

        public async Task<string> GetOrSetAsync(string key, Func<Task<string>> task)
        {
            var connection = await redisConnection;

            var result = await connection.BasicRetryAsync(async (db) => await db.StringGetAsync(key));

            if (result.HasValue)
            {
                return result;
            }
            else
            {
                var newValue = await task();
                await connection.BasicRetryAsync(async (db) => await db.StringSetAsync(key, newValue));

                return newValue;
            }

        }

        public async Task RemoveAsync(string key)
        {
            var connection = await redisConnection;
            await connection.BasicRetryAsync(async (db) => await db.KeyDeleteAsync(key));
        }
    }
}
