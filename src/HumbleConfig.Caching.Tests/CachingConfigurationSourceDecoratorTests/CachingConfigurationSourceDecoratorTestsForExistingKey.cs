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
    public class CachingConfigurationSourceDecoratorTestsForExistingKey<TValue> : ConfigurationSourceTestsForExistingKey<TValue>
    {
        protected override IConfigurationSource GivenConfigurationSourceWithExistingRKey(string key, TValue expectedValue)
        {
            var innerSource = new Mock<IConfigurationSource>();
                    var cancellationToken = new CancellationToken();
            innerSource.Setup(x => x.GetAppSettingAsync<TValue>(key, cancellationToken))
                .ReturnsAsync(ConfigurationSourceResult<TValue>.SuccessResult(expectedValue));

            var cacheItemPolicy = new CacheItemPolicy()
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(1)
            };
            var source = new CachingConfigurationSourceDecorator(innerSource.Object, MemoryCache.Default, cacheItemPolicy);

            return source;
        }
    }
}
