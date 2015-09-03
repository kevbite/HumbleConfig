using NUnit.Framework;

namespace HumbleConfig.ConfigurationManager.Tests.ConfigurationManagerSourceTest
{
    [TestFixture]
    public class ConfigurationManagerSourceTestsForExistingAppSettingKey
    {
        private ConfigurationManagerSource _source;
        private bool _result;
        private string _value;

        [TestFixtureSetUp]
        public void ConfigurationManagerSourceTestsWithExistingAppSettingKey()
        {
            _source = new ConfigurationManagerSource();
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
