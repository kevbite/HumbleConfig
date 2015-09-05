using NUnit.Framework;

namespace HumbleConfig.Tests.ConfigurationTests
{
    public class ConfigurationTestsForNoSources<TValue> : ValueTests<TValue>
    {
        private Configuration _configuration;
        private TValue _value;

        [TestFixtureSetUp]
        public void GivenAConfigurationWithNoSourcesLoaded()
        {
            _configuration = new Configuration();
        }

        [SetUp]
        public void WhenGettingAnAppSetting()
        {
            _value = _configuration.GetAppSetting<TValue>("key");
        }

        [Test]
        public void ThenTheReturnValueIsNull()
        {
            Assert.That(_value, Is.EqualTo(default(TValue)));
        }
    }
}
