namespace HumbleConfig.Caching
{
    public class CacheKeyCreator : ICacheKeyCreator
    {
        private readonly string _keyPrefix;

        public CacheKeyCreator(string keyPrefix)
        {
            _keyPrefix = keyPrefix;
        }

        public string CreateCacheKey(string key)
        {
            return $"{_keyPrefix}-{key}";
        }
    }
}