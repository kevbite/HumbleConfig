using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HumbleConfig.Caching;
using HumbleConfig.InMemory;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.FunctionalTests
{
    [TestFixture]
    public class CacheConfigurationTests
    {
        private IConfiguration _configuration;

        private string key1;
        private Dictionary<string, object> _inMemory;
        private Fixture _fixture;

        [OneTimeSetUp]
        public void GivenConfigurationWithEnvironmentVaribleAndConfigurationManager()
        {
            _fixture = new Fixture();
            key1 = _fixture.Create("key1");
            _inMemory = new Dictionary<string, object>()
            {
                { key1, "InMemory1"},
            };

            _configuration = new Configuration()
                .AddInMemory(_inMemory)
                .WithDefaultMemoryCache(TimeSpan.FromSeconds(1))
                .GetConfiguration();
        }

        [Test]
        public async Task WhenChangingValueStillReturnsTheSameValue()
        {
            var value1 = await _configuration.GetAppSettingAsync<string>(key1);

            _inMemory[key1] = _fixture.Create("key1");

            var value2 = await _configuration.GetAppSettingAsync<string>(key1);

            Assert.AreEqual(value1, value2);
        }
    }
}