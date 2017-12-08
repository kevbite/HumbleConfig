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
            
            var source = new CachingConfigurationSourceDecorator(innerSource.Object, MemoryCache.Default, () => new CacheItemPolicy());

            return source;
        }
    }
}