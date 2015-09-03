using HumbleConfig.Tests.Stubs;
using NUnit.Framework;

namespace HumbleConfig.Tests.ConfigurationTests
{
    [TestFixture]
    public class ConfigurationTestsForOneSourceThatHasNoMatchingKey
    {
        private Configuration _configuration;
        private string _value;

        [TestFixtureSetUp]
        public void GivenAConfigurationWithOneSourceThatHasNoMatchingKey()
        {
            _configuration = new Configuration();

            var source = new ConfigurationSourceStub();
            _configuration.AddConfigurationSource(source);
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
