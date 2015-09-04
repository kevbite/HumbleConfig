using ConfigR;
using NUnit.Framework;

namespace HumbleConfig.ConfigR.Tests.ConfigRSourceTests
{
    [TestFixture]
    public class ConfigRSourceTestsForNoneExistingConfigRKey
    {
        private ConfigRSource _source;
        private bool _result;
        private string _value;

        [TestFixtureSetUp]
        public void ConfigRSourceTestsWithNoneExistingConfigRKey()
        {
            _source = new ConfigRSource(Config.Global);
        }
        
        [SetUp]
        public void WhenTryingToGetTheAppSettings()
        {
            _result = _source.TryGetAppSetting("NotHere", out _value);
        }
    
        [Test]
        public void ThenNullIsReturned()
        {
            Assert.That(_value, Is.Null);
        }

        [Test]
        public void ThenTheResultIsFalse()
        {
            Assert.That(_result, Is.False);
        }
    }
}
