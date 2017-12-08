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
    public class CachingConfigurationSourceDecoratorTestsForExistingKeyWithValueCached<TValue> : ConfigurationSourceTestsForExistingKey<TValue>
    {
        protected override IConfigurationSource GivenConfigurationSourceWithExistingRKey(string key, TValue expectedValue)
        {
            var innerSource = new Mock<IConfigurationSource>();
            var cancellationToken = new CancellationToken();
            innerSource.SetupSequence(x => x.GetAppSettingAsync<TValue>(key, cancellationToken))
                .ReturnsAsync(ConfigurationSourceResult<TValue>.SuccessResult(expectedValue))
                .Throws(new Exception("Should never get here"));

            var cacheItemPolicy = new CacheItemPolicy()
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(1)
            };
            var source = new CachingConfigurationSourceDecorator(innerSource.Object, MemoryCache.Default, cacheItemPolicy);
            source.GetAppSettingAsync<TValue>(key, cancellationToken).Wait();

            return source;
        }
    }
}