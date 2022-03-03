namespace Inoxie.Tools.RedisCache.Services
{
    internal class RedisKeyProvider
    {
        private readonly string databaseName;

        public RedisKeyProvider(string databaseName)
        {
            this.databaseName = databaseName;
        }

        public string GetKey(string key, string subKey)
        {
            if (string.IsNullOrWhiteSpace(databaseName))
            {
                return $"{key}:{subKey}";
            }

            return $"{databaseName}:{key}:{subKey}";
        }
    }
}
