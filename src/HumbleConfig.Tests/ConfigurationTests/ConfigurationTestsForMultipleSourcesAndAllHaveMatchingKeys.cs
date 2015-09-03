using HumbleConfig.Tests.Stubs;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.Tests.ConfigurationTests
{
    [TestFixture]
    public class ConfigurationTestsForMultipleSourcesAndAllHaveMatchingKeys
    {
        private Configuration _configuration;
        private string[] _values;

        private ConfigurationSourceStub _source1;
        private ConfigurationSourceStub _source2;
        private string _key;

        [TestFixtureSetUp]
        public void GivenAConfigurationWithMultipleSourcesAndAllHaveMatchingKeys()
        {
            var fixture = new Fixture();
            _key = fixture.Create<string>();
            _configuration = new Configuration();

            _source1 = new ConfigurationSourceStub();
            _source1.AppSettings.Add(_key, fixture.Create<string[]>());

            _source2 = new ConfigurationSourceStub();
            _source2.AppSettings.Add(_key, fixture.Create<string[]>());

            _configuration.AddConfigurationSource(_source1);
            _configuration.AddConfigurationSource(_source2);
        }

        [SetUp]
        public void WhenGettingAnAppSettings()
        {
            _values = _configuration.GetAppSettings(_key);
        }

        [Test]
        public void ThenTheValueReturnedMatchesTheFirstSource()
        {
            Assert.That(_values, Is.EqualTo(_source1.AppSettings[_key]));
        }
    }
}
