using System.Collections.Generic;
using System.Runtime.Caching;
using System.Threading.Tasks;
using HumbleConfig.Caching;
using HumbleConfig.InMemory;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.FunctionalTests
{
    [TestFixture]
    public class MultiCacheConfigurationTests
    {
        private IConfiguration _configuration;

        private string _key1;
        private Dictionary<string, object> _inMemory;
        private Fixture _fixture;

        [OneTimeSetUp]
        public void GivenConfigurationWithEnvironmentVaribleAndConfigurationManager()
        {
            _fixture = new Fixture();
            _key1 = _fixture.Create("key1");
            _inMemory = new Dictionary<string, object>()
            {
                { _key1, "InMemory1"},
            };

            _configuration = new Configuration()
                .AddInMemory(new Dictionary<string, object>()).WithDefaultMemoryCache(() => new CacheItemPolicy())
                .AddInMemory(new Dictionary<string, object>{{ _key1, "InMemory1"}}).WithDefaultMemoryCache(() => new CacheItemPolicy())
                .GetConfiguration();
        }

        [Test]
        public async Task WhenChangingValueStillReturnsTheSameValue()
        {
            var value1 = await _configuration.GetAppSettingAsync<string>(_key1);
            var value2 = await _configuration.GetAppSettingAsync<string>(_key1);

            Assert.AreEqual(value1, "InMemory1");
            Assert.AreEqual(value2, "InMemory1");
        }
    }
}