using System;
using System.Runtime.Caching;
using System.Threading;
using System.Threading.Tasks;

namespace HumbleConfig.Caching
{
    public class CachingConfigurationSourceDecorator : IConfigurationSource
    {
        private readonly IConfigurationSource _innerSource;
        private readonly ICacheKeyCreator _cacheKeyCreator;
        private readonly ObjectCache _objectCache;
        private readonly Func<CacheItemPolicy> _cacheItemPolicyFactory;

        public CachingConfigurationSourceDecorator(IConfigurationSource innerSource, ICacheKeyCreator cacheKeyCreator, ObjectCache objectCache, Func<CacheItemPolicy> cacheItemPolicyFactoryFactory)
        {
            _innerSource = innerSource;
            _cacheKeyCreator = cacheKeyCreator;
            _objectCache = objectCache;
            _cacheItemPolicyFactory = cacheItemPolicyFactoryFactory;
        }

        public async Task<ConfigurationSourceResult<TValue>> GetAppSettingAsync<TValue>(string key, CancellationToken cancellationToken = default(CancellationToken))
        {
            var appsetting = (ConfigurationSourceResult<TValue>)_objectCache.Get(_cacheKeyCreator.CreateCacheKey(key));

            if (appsetting == null)
            {
                appsetting = await _innerSource.GetAppSettingAsync<TValue>(key, cancellationToken)
                    .ConfigureAwait(false);

                var cacheItemPolicy = _cacheItemPolicyFactory();
                _objectCache.Add(CreateCacheItem(key, appsetting), cacheItemPolicy);
            }

            return appsetting;
        }
        

        private CacheItem CreateCacheItem<TValue>(string key, ConfigurationSourceResult<TValue> value)
        {
            return new CacheItem(_cacheKeyCreator.CreateCacheKey(key), value);
        }
    }
}
