using System.Collections.Generic;
using HumbleConfig.InMemory;
using NUnit.Framework;

namespace HumbleConfig.Tests.InMemory.InMemorySourceTests
{
    [TestFixture]
    public class InMemorySourceTestsForNoneExistingAppSettingKey
    {
        private InMemorySource _source;
        private bool _result;
        private string _value;

        [TestFixtureSetUp]
        public void InMemorySourceTestsWithNoneExistingAppSettingKey()
        {
            _source = new InMemorySource(new Dictionary<string, object>());
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
