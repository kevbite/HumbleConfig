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
            
            var source = new CachingConfigurationSourceDecorator(innerSource.Object, new CacheKeyCreator(Guid.NewGuid().ToString()), MemoryCache.Default, () => new CacheItemPolicy());
            source.GetAppSettingAsync<TValue>(key, cancellationToken).Wait();

            return source;
        }
    }
}