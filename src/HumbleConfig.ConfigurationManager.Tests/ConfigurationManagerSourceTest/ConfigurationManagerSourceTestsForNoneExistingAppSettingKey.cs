using NUnit.Framework;

namespace HumbleConfig.ConfigurationManager.Tests.ConfigurationManagerSourceTest
{
    [TestFixture]
    public class ConfigurationManagerSourceTestsForNoneExistingAppSettingKey
    {
        private ConfigurationManagerSource _source;
        private bool _result;
        private string _value;

        [TestFixtureSetUp]
        public void ConfigurationManagerSourceTestsWithNoneExistingAppSettingKey()
        {
            _source = new ConfigurationManagerSource();
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
