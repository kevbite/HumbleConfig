using System;
using System.Runtime.Caching;
using System.Threading;
using HumbleConfig.Tests;
using Moq;
using NUnit.Framework;

namespace HumbleConfig.Caching.Tests.CachingConfigurationSourceDecoratorTests
{
    [TestFixtureSource(typeof(NonNullableTestFixtureCases))]
    [TestFixtureSource(typeof(NullableTestFixtureCases))]
    public class CachingConfigurationSourceDecoratorForNoneExistingAppSettingKey<TValue> : ConfigurationSourceTestsForNoneExistingKey<TValue>
    {
        protected override IConfigurationSource CreateConfigurationSource()
        {
            var innerSource = new Mock<IConfigurationSource>();
            innerSource.Setup(x => x.GetAppSettingAsync<TValue>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(ConfigurationSourceResult<TValue>.FailedResult());

            var cacheItemPolicy = new CacheItemPolicy()
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(1)
            };

            var source = new CachingConfigurationSourceDecorator(innerSource.Object, MemoryCache.Default, cacheItemPolicy);

            return source;
        }
    }
}