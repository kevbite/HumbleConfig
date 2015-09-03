using HumbleConfig.Tests.Stubs;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.Tests.ConfigurationTests
{
    [TestFixture]
    public class ConfigurationTestsForOneSourceThatHasAMatchingKey
    {
        private string _key;
        private Configuration _configuration;
        private ConfigurationSourceStub _source;
        private string _value;
        

        [TestFixtureSetUp]
        public void GivenAConfigurationWithOneSourceThatHasAMatchingKey()
        {
            var fixture = new Fixture();
            _key = fixture.Create<string>();
            _configuration = new Configuration();

            _source = new ConfigurationSourceStub();
            _source.AppSettings.Add(_key, fixture.Create<string>());
            _configuration.AddConfigurationSource(_source);
        }

        [SetUp]
        public void WhenGettingAnAppSetting()
        {
            _value = _configuration.GetAppSetting(_key);
        }

        [Test]
        public void ThenTheValueReturnedMatchesSource()
        {
            Assert.That(_value, Is.EqualTo(_source.AppSettings[_key]));
        }
    }
}
