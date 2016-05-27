using System.Runtime.InteropServices;
using HumbleConfig.Tests.Stubs;
using NUnit.Framework;

namespace HumbleConfig.Tests.ConfigurationTests
{
    [TestFixtureSource(typeof(NullableTestFixtureCases))]
    public class ConfigurationTestsForOneSourceThatHasNoMatchingKeyForNullables<TValue>
    {
        private Configuration _configuration;
        private TValue _value;

        [OneTimeSetUp]
        public void GivenAConfigurationWithOneSourceThatHasNoMatchingKey()
        {
            _configuration = new Configuration();

            var source = new ConfigurationSourceStub();
            _configuration.AddConfigurationSource(source);
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
