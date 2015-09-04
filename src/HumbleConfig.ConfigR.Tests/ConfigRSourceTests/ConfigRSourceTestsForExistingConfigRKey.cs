using ConfigR;
using NUnit.Framework;

namespace HumbleConfig.ConfigR.Tests.ConfigRSourceTests
{
    [TestFixture]
    public class ConfigRSourceTestsForExistingConfigRKey
    {
        private ConfigRSource _source;
        private bool _result;
        private string _value;

        [TestFixtureSetUp]
        public void ConfigRSourceTestsWithExistingConfigRKey()
        {
            _source = new ConfigRSource(Config.Global);
        }
        
        [SetUp]
        public void WhenTryingToGetTheAppSettings()
        {
            _result = _source.TryGetAppSetting("TestKey", out _value);
        }
    
        [Test]
        public void ThenTheCorrectValueIsReturned()
        {
            var expected = "TestValue";

            Assert.That(_value, Is.EqualTo(expected));
        }

        [Test]
        public void ThenTheResultIsTrue()
        {
            Assert.That(_result, Is.True);
        }
    }
}
