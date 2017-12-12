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
    public class CachingConfigurationSourceDecoratorForNoneExistingAppSettingKeyWithValueCached<TValue> : ConfigurationSourceTestsForNoneExistingKey<TValue>
    {
        protected override IConfigurationSource CreateConfigurationSource()
        {
            var objectCache = new Mock<ObjectCache>();
            objectCache.Setup(x => x.Get(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(ConfigurationSourceResult<TValue>.FailedResult());

            var innerSource = new Mock<IConfigurationSource>();
            innerSource.Setup(x => x.GetAppSettingAsync<TValue>(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Throws(new Exception("Should never get here"));

            var source = new CachingConfigurationSourceDecorator(innerSource.Object, new CacheKeyCreator(Guid.NewGuid().ToString()), objectCache.Object, () => new CacheItemPolicy());
            
            return source;
        }
    }
}