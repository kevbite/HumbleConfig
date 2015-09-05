using HumbleConfig.Tests.Stubs;
using NUnit.Framework;

namespace HumbleConfig.Tests.ConfigurationTests
{
    public class ConfigurationTestsForOneSourceThatHasNoMatchingKey<TValue> : ValueTests<TValue>
    {
        private Configuration _configuration;
        private TValue _value;

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
            _value = _configuration.GetAppSetting<TValue>("key");
        }

        [Test]
        public void ThenTheReturnValueIsNull()
        {
            Assert.That(_value, Is.EqualTo(default(TValue)));
        }
    }
}
