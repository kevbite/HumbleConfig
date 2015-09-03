using NUnit.Framework;

namespace HumbleConfig.Tests.ConfigurationTests
{
    [TestFixture]
    public class ConfigurationTestsForNoSources
    {
        private Configuration _configuration;
        private string _value;

        [TestFixtureSetUp]
        public void GivenAConfigurationWithNoSourcesLoaded()
        {
            _configuration = new Configuration();
        }

        [SetUp]
        public void WhenGettingAnAppSetting()
        {
            _value = _configuration.GetAppSetting("key");
        }

        [Test]
        public void ThenTheReturnValueIsNull()
        {
            Assert.That(_value, Is.Null);
        }
    }
}
