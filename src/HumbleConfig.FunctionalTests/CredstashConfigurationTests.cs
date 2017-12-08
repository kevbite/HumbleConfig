using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Amazon;
using ConfigR;
using HumbleConfig.ConfigR;
using HumbleConfig.ConfigurationManager;
using HumbleConfig.Credstash;
using HumbleConfig.EnvironmentVariables;
using HumbleConfig.InMemory;
using HumbleConfig.MongoDb;
using NUnit.Framework;

namespace HumbleConfig.FunctionalTests
{

    [TestFixture]
    [Category("Credstash")]
    public class CredstashConfigurationTests
    {
        private IConfiguration _configuration;

        private string key1 = "key1";
        private string key2 = "key2";

        private string _key1Actual;
        private string _key2Actual;

        [OneTimeSetUp]
        public void GivenConfigurationWithEnvironmentVaribleAndConfigurationManager()
        {
            // This test requires the following commands to be run:
            // $ credstash --table credstash-test-2E24F0AC-DD37-4DE1-939E-E2D1ADF66149 setup
            // $ credstash --table credstash-test-2E24F0AC-DD37-4DE1-939E-E2D1ADF66149 put key1 Credstash
            _configuration = new Configuration()
                .AddCredstash(RegionEndpoint.EUWest1, "credstash-test-2E24F0AC-DD37-4DE1-939E-E2D1ADF66149")
                .AddInMemory(new Dictionary<string, object>() {{key2, "InMemory"}})
                .GetConfiguration();
        }

        [SetUp]
        public async Task WhenGettingAppSettings()
        {
            _key1Actual = await _configuration.GetAppSettingAsync<string>(key1);
            _key2Actual = await _configuration.GetAppSettingAsync<string>(key2);
        }


        [Test]
        public void ThenKey5PullsFromCredstash()
        {
            Assert.That(_key1Actual, Is.EqualTo("Credstash"));
        }

        [Test]
        public void ThenKey5PullsFromInMemory()
        {
            Assert.That(_key2Actual, Is.EqualTo("InMemory"));
        }
    }
}
