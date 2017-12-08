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
        private readonly Func<CacheItemPolicy> _cacheItemPolicyFactory;

        public CachingConfigurationSourceDecorator(IConfigurationSource innerSource, ObjectCache objectCache, Func<CacheItemPolicy> cacheItemPolicyFactoryFactory)
        {
            _innerSource = innerSource;
            _objectCache = objectCache;
            _cacheItemPolicyFactory = cacheItemPolicyFactoryFactory;
        }

        public async Task<ConfigurationSourceResult<TValue>> GetAppSettingAsync<TValue>(string key, CancellationToken cancellationToken = default(CancellationToken))
        {
            var appsetting = (ConfigurationSourceResult<TValue>)_objectCache.Get(CreateCacheKey(key));

            if (appsetting == null)
            {
                appsetting = await _innerSource.GetAppSettingAsync<TValue>(key, cancellationToken);

                var cacheItemPolicy = _cacheItemPolicyFactory();
                _objectCache.Add(CreateCacheItem(key, appsetting), cacheItemPolicy);
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
