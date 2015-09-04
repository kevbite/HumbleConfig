using System.Collections.Generic;
using HumbleConfig.InMemory;
using HumbleConfig.KeyFormatters;
using NUnit.Framework;

namespace HumbleConfig.FunctionalTests
{
    [TestFixture]
    public class ConfigurationTestsWithKeyPrefixer
    {
        private IConfiguration _configuration;
        
        private string _key1Actual;
        
        [TestFixtureSetUp]
        public void GivenConfigurationWithKeyPrefixer()
        {
            _configuration = new Configuration()
                .WithKeyPrefixer("HumbleConfig:")
                .AddInMemory(new Dictionary<string, object>() { { "HumbleConfig:Key1", "InMemory"} });
        }

        [SetUp]
        public void WhenGettingAppSettings()
        {
            _key1Actual = _configuration.GetAppSetting("Key1");
        }

        [Test]
        public void ThenKey1PullsValueFromEnvironmentVariable()
        {
            Assert.That(_key1Actual, Is.EqualTo("InMemory"));
        }
    }
}
