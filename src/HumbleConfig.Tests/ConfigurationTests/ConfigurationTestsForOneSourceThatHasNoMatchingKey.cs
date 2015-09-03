using HumbleConfig.Tests.Stubs;
using Moq;
using NUnit.Framework;

namespace HumbleConfig.Tests.ConfigurationTests
{
    [TestFixture]
    public class ConfigurationTestsForOneSourceThatHasNoMatchingKey
    {
        private Configuration _configuration;
        private string[] _values;

        [TestFixtureSetUp]
        public void GivenAConfigurationWithOneSourceThatHasNoMatchingKey()
        {
            _configuration = new Configuration();

            var source = new ConfigurationSourceStub();
            _configuration.AddConfigurationSource(source);
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
