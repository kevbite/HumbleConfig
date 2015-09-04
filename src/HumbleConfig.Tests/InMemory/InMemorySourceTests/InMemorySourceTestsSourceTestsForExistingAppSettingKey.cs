using System.Collections.Generic;
using System.Linq;
using HumbleConfig.InMemory;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.Tests.InMemory.InMemorySourceTests
{
    [TestFixture]
    public class InMemorySourceTestsSourceTestsForExistingAppSettingKey
    {
        private InMemorySource _source;
        private bool _result;
        private string _value;
        private Dictionary<string, object> _appSettings;
        private string _key;

        [TestFixtureSetUp]
        public void InMemorySourceTestsWithExistingAppSettingKey()
        {
            _appSettings = new Fixture().Create<Dictionary<string, string>>()
                .ToDictionary(x => x.Key, x => (object)x.Value);
            _key = _appSettings.Keys.First();

            _source = new InMemorySource(_appSettings);
        }

        [SetUp]
        public void WhenTryingToGetTheAppSettings()
        {
            _result = _source.TryGetAppSetting(_key, out _value);
        }

        [Test]
        public void ThenTheCorrectValueIsReturned()
        {
            Assert.That(_value, Is.EqualTo(_appSettings[_key]));
        }

        [Test]
        public void ThenTheResultIsTrue()
        {
            Assert.That(_result, Is.True);
        }
    }
}
