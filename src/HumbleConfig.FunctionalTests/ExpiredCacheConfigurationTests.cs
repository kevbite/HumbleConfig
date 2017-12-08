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
    public class ExpiredCacheConfigurationTests
    {
        private IConfiguration _configuration;

        private string _key1;
        private string _key2;
        private Dictionary<string, object> _inMemory;
        private Fixture _fixture;
        private readonly List<TestChangeMonitor> _changeMonitors = new List<TestChangeMonitor>();

        [OneTimeSetUp]
        public void GivenConfigurationWithEnvironmentVaribleAndConfigurationManager()
        {
            _fixture = new Fixture();
            _key1 = _fixture.Create("key1");
            _key2 = _fixture.Create("key2");
            _inMemory = new Dictionary<string, object>()
            {
                { _key1, "InMemory1"},
                { _key2, "InMemory2"},
            };

            CacheItemPolicy CreateCacheItemPolicy()
            {
                var changeMonitor = new TestChangeMonitor();
                _changeMonitors.Add(changeMonitor);
                var cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.ChangeMonitors.Add(changeMonitor);

                return cacheItemPolicy;
            }

            _configuration = new Configuration()
                .AddInMemory(_inMemory)
                .WithDefaultMemoryCache(CreateCacheItemPolicy)
                .GetConfiguration();
        }

        [Test]
        public async Task WhenChangingValueStillReturnsTheSameValue()
        {
            var key1Value1 = await _configuration.GetAppSettingAsync<string>(_key1);
            var key2Value1 = await _configuration.GetAppSettingAsync<string>(_key2);
            Assert.AreEqual("InMemory1", key1Value1);
            Assert.AreEqual("InMemory2", key2Value1);

            var key1Expected = _fixture.Create("key1");
            _inMemory[_key1] = key1Expected;
            var key2Expected = _fixture.Create("key2");
            _inMemory[_key2] = key2Expected;

            _changeMonitors.ForEach(monitor => monitor.TriggerChange());

            var key1Value2 = await _configuration.GetAppSettingAsync<string>(_key1);
            var key2Value2 = await _configuration.GetAppSettingAsync<string>(_key2);

            Assert.AreEqual(key1Expected, key1Value2);
            Assert.AreEqual(key2Expected, key2Value2);
        }

        public class TestChangeMonitor : ChangeMonitor
        {
            public TestChangeMonitor()
            {
                InitializationComplete();
            }
            protected override void Dispose(bool disposing) { }

            public override string UniqueId { get; }

            public void TriggerChange()
            {
                OnChanged(null);
            }
        }
    }
}