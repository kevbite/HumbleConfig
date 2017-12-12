using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HumbleConfig.Caching;
using HumbleConfig.InMemory;
using HumbleConfig.KeyFormatters;
using HumbleConfig.MongoDb;
using MongoDB.Driver;
using Moq;
using NUnit.Framework;

namespace HumbleConfig.FunctionalTests
{
    [TestFixture]
    class KeyFormatterConfigurationTests
    {
        private IConfiguration _configuration;

        private string key1 = "key1";
        private string key2 = "key2";
        private string key3 = "key3";
        
        private string _key1Actual;
        private string _key2Actual;
        private string _key3Actual;
        
        [OneTimeSetUp]
        public void GivenConfigurationWithEnvironmentVaribleAndConfigurationManager()
        {
            var newKey3 = "key3.new";
            var keyFormatter = new Mock<IKeyFormatter>();
            keyFormatter.Setup(x => x.FormatKey(key3))
                .Returns(newKey3);

            _configuration = new Configuration()
                .AddInMemory(new Dictionary<string, object>(){{"pre." + key1, "InMemory1"}}).WithKeyPrefixer("pre.")
                .AddInMemory(new Dictionary<string, object>(){{key2 + ".post", "InMemory2"}}).WithKeyPostfixer(".post")
                .AddInMemory(new Dictionary<string, object>(){{newKey3, "InMemory3"}}).WithKeyFormatter(keyFormatter.Object)
                .GetConfiguration();
        }

        [SetUp]
        public async Task WhenGettingAppSettings()
        {
            _key1Actual = await _configuration.GetAppSettingAsync<string>(key1);
            _key2Actual = await _configuration.GetAppSettingAsync<string>(key2);
            _key3Actual = await _configuration.GetAppSettingAsync<string>(key3);
        }

        [Test]
        public void ThenTheCorrectValueIsPullWithPrefix()
        {
            Assert.That(_key1Actual, Is.EqualTo("InMemory1"));
        }

        [Test]
        public void ThenTheCorrectValueIsPullWithPostfix()
        {
            Assert.That(_key2Actual, Is.EqualTo("InMemory2"));
        }

        [Test]
        public void ThenTheCorrectValueIsPullWithCustomFormatter()
        {
            Assert.That(_key3Actual, Is.EqualTo("InMemory3"));
        }
    }
}
