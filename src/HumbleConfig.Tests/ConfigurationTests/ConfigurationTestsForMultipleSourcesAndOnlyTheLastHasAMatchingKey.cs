using HumbleConfig.Tests.Stubs;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.Tests.ConfigurationTests
{
    [TestFixture]
    public class ConfigurationTestsForMultipleSourcesAndOnlyTheLastHasAMatchingKey
    {
        private Configuration _configuration;
        private string _value;

        private ConfigurationSourceStub _source1;
        private ConfigurationSourceStub _source2;
        private string _key;

        [TestFixtureSetUp]
        public void GivenAConfigurationWithTwoSourcesAndOnlyTheLastHasAMatchingKey()
        {
            var fixture = new Fixture();
            _key = fixture.Create<string>();
            _configuration = new Configuration();

            _source1 = new ConfigurationSourceStub();

            _source2 = new ConfigurationSourceStub();
            _source2.AppSettings.Add(_key, fixture.Create<string>());

            _configuration.AddConfigurationSource(_source1);
            _configuration.AddConfigurationSource(_source2);
        }

        [SetUp]
        public void WhenGettingAnAppSetting()
        {
            _value = _configuration.GetAppSetting(_key);
        }

        [Test]
        public void ThenTheValueReturnedMatchesTheLastSource()
        {
            Assert.That(_value, Is.EqualTo(_source2.AppSettings[_key]));
        }
    }
}
