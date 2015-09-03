using System;
using HumbleConfig.ConfigurationManager;
using HumbleConfig.EnvironmentVariables;
using NUnit.Framework;

namespace HumbleConfig.FunctionalTests
{
    [TestFixture]
    public class ConfigurationWithEnvironmentVaribleAndConfigurationManagerTests
    {
        private IConfiguration _configuration;
        private string key1 = "key1";
        private string key2 = "key2";
        private string key3 = "key3";
        private string key4 = "key4";
        private string _key1Actual;
        private string _key2Actual;
        private string _key3Actual;
        private string _key4Actual;

        [TestFixtureSetUp]
        public void GivenConfigurationWithEnvironmentVaribleAndConfigurationManager()
        {
            Environment.SetEnvironmentVariable(key1, "EnvironmentVariable");
            Environment.SetEnvironmentVariable(key2, "EnvironmentVariable");

            _configuration = new Configuration()
                .AddEnvironmentVariables()
                .AddConfigurationManager();
        }

        [SetUp]
        public void WhenGettingAppSettings()
        {
            _key1Actual = _configuration.GetAppSetting(key1);
            _key2Actual = _configuration.GetAppSetting(key2);
            _key3Actual = _configuration.GetAppSetting(key3);
            _key4Actual = _configuration.GetAppSetting(key4);
        }

        [Test]
        public void ThenKey1PullsValueFromEnvironmentVariable()
        {
            Assert.That(_key1Actual, Is.EqualTo("EnvironmentVariable"));
        }

        [Test]
        public void ThenKey2PullsValueFromEnvironmentVariable()
        {
            Assert.That(_key2Actual, Is.EqualTo("EnvironmentVariable"));
        }

        [Test]
        public void ThenKey3PullsValueFromAppConfig()
        {
            Assert.That(_key3Actual, Is.EqualTo("App.Config"));
        }

        [Test]
        public void ThenKey4IsNull()
        {
            Assert.That(_key4Actual, Is.Null);
        }
    }
}
