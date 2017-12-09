using System;
using System.Runtime.Caching;
using System.Threading;

namespace HumbleConfig.Caching
{
    public static class CachingExtentions
    {
        public static IConfigurationSourceConfigurator WithCache(this IConfigurationSourceConfigurator configurationSourceConfigurator, ICacheKeyCreator cacheKeyCreator, ObjectCache objectCache, Func<CacheItemPolicy> cacheItemPolicyFactory)
        {
            return configurationSourceConfigurator.WrapSource(x => new CachingConfigurationSourceDecorator(x, cacheKeyCreator, objectCache, cacheItemPolicyFactory));
        }

        public static IConfigurationSourceConfigurator WithCache(this IConfigurationSourceConfigurator configurationSourceConfigurator, ObjectCache objectCache, Func<CacheItemPolicy> cacheItemPolicyFactory)
        {
            var cacheKeyCreator = new CacheKeyCreator(Guid.NewGuid().ToString());

            return WithCache(configurationSourceConfigurator, cacheKeyCreator, objectCache, cacheItemPolicyFactory);
        }

        public static IConfigurationSourceConfigurator WithDefaultMemoryCache(this IConfigurationSourceConfigurator configurationSourceConfigurator, Func<CacheItemPolicy> cacheItemPolicyFactory)
        {
            return WithCache(configurationSourceConfigurator, MemoryCache.Default, cacheItemPolicyFactory);
        }

        public static IConfigurationSourceConfigurator WithDefaultMemoryCache(this IConfigurationSourceConfigurator configurationSourceConfigurator, TimeSpan expiresAfter)
        {
            return WithDefaultMemoryCache(configurationSourceConfigurator, () => new CacheItemPolicy()
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.Add(expiresAfter)
            });
        }
    }
}