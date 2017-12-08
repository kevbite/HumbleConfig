using System;
using System.Runtime.Caching;
using System.Threading;

namespace HumbleConfig.Caching
{
    public static class CachingExtentions
    {
        public static IConfigurationSourceConfigurator WithCache(this IConfigurationSourceConfigurator a, ObjectCache objectCache, Func<CacheItemPolicy> cacheItemPolicyFactory)
        {
            return a.WrapSource(x => new CachingConfigurationSourceDecorator(x, objectCache, cacheItemPolicyFactory));
        }

        public static IConfigurationSourceConfigurator WithDefaultMemoryCache(this IConfigurationSourceConfigurator a, Func<CacheItemPolicy> cacheItemPolicyFactory)
        {
            return a.WrapSource(x => new CachingConfigurationSourceDecorator(x, MemoryCache.Default, cacheItemPolicyFactory));
        }

        public static IConfigurationSourceConfigurator WithDefaultMemoryCache(this IConfigurationSourceConfigurator a, TimeSpan expiresAfter)
        {
            return a.WrapSource(x => new CachingConfigurationSourceDecorator(x, MemoryCache.Default, () => new CacheItemPolicy()
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.Add(expiresAfter)
            }));
        }
    }
}