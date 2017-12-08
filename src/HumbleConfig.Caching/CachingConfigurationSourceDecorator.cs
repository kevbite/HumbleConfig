using System;
using System.Runtime.Caching;
using System.Threading;
using System.Threading.Tasks;

namespace HumbleConfig.Caching
{
    public class CachingConfigurationSourceDecorator : IConfigurationSource
    {
        private readonly IConfigurationSource _innerSource;
        private readonly ObjectCache _objectCache;
        private readonly CacheItemPolicy _cacheItemPolicy;

        public CachingConfigurationSourceDecorator(IConfigurationSource innerSource, ObjectCache objectCache, CacheItemPolicy cacheItemPolicy)
        {
            _innerSource = innerSource;
            _objectCache = objectCache;
            _cacheItemPolicy = cacheItemPolicy;
        }

        public async Task<ConfigurationSourceResult<TValue>> GetAppSettingAsync<TValue>(string key, CancellationToken cancellationToken = default(CancellationToken))
        {
            var appsetting = (ConfigurationSourceResult<TValue>)_objectCache.Get(CreateCacheKey(key));

            if (appsetting == null)
            {
                appsetting = await _innerSource.GetAppSettingAsync<TValue>(key, cancellationToken);

                _objectCache.Add(CreateCacheItem(key, appsetting), _cacheItemPolicy);
            }

            return appsetting;
        }

        private static string CreateCacheKey(string key)
        {
            return $"HumbleConfig-{key}";
        }

        private CacheItem CreateCacheItem<TValue>(string key, ConfigurationSourceResult<TValue> value)
        {
            return new CacheItem(CreateCacheKey(key), value);
        }
    }
}
