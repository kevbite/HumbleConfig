using NUnit.Framework;

namespace HumbleConfig.Tests.ConfigurationTests
{
    [TestFixtureSource(typeof(NullableTestFixtureCases))]
    public class ConfigurationTestsForNoSourcesForNullableValues<TValue>
    {
        private Configuration _configuration;
        private TValue _value;

        [OneTimeSetUp]
        public void GivenAConfigurationWithNoSourcesLoaded()
        {
            _configuration = new Configuration();
        }

        [SetUp]
        public void WhenGettingAnAppSetting()
        {
            _value = _configuration.GetAppSettingAsync<TValue>("key").Result;
        }

        [Test]
        public void ThenTheReturnValueIsNull()
        {
            Assert.That(_value, Is.Null);
        }
    }
}
