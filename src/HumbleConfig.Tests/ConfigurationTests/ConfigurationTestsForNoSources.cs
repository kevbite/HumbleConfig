using NUnit.Framework;

namespace HumbleConfig.Tests.ConfigurationTests
{
    [TestFixture]
    public class ConfigurationTestsForNoSources
    {
        private Configuration _configuration;
        private string[] _values;

        [TestFixtureSetUp]
        public void GivenAConfigurationWithNoSourcesLoaded()
        {
            _configuration = new Configuration();
        }

        [SetUp]
        public void WhenGettingAnAppSettings()
        {
            _values = _configuration.GetAppSettings("key");
        }

        [Test]
        public void ThenTheReturnValueIsNull()
        {
            Assert.That(_values, Is.Null);
        }
    }
}
