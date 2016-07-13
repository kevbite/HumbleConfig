using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.Tests
{
    [TestFixtureSource(typeof(NonNullableTestFixtureCases))]
    [TestFixtureSource(typeof(NullableTestFixtureCases))]
    public abstract class ConfigurationSourceTestsForExistingKey<TValue>
    {
        private IConfigurationSource _source;
        private ConfigurationSourceResult<TValue> _result;
        private readonly Fixture _fixture = new Fixture();
        private string _key;
        private TValue _expectedValue;

        [OneTimeSetUp]
        public void GivenConfigurationSourceWithExistingRKey()
        {
            _key = _fixture.Create<string>();
            _expectedValue = _fixture.Create<TValue>();

            _source = GivenConfigurationSourceWithExistingRKey(_key, _expectedValue);
        }

        protected abstract IConfigurationSource GivenConfigurationSourceWithExistingRKey(string key, TValue expectedValue);

        [SetUp]
        public void WhenTryingToGetTheAppSettings()
        {
            _result = _source.GetAppSettingAsync<TValue>(_key).Result;
        }

        [Test]
        public void ThenTheCorrectValueIsReturned()
        {
            Assert.That(_result.Value, Is.EqualTo(_expectedValue));
        }

        [Test]
        public void ThenTheResultKeyExistsIsTrue()
        {
            Assert.That(_result.KeyExists, Is.True);
        }

        [OneTimeTearDown]
        public void DestroyEvidence()
        {
            DestroyEvidence(_key);
        }

        protected virtual void DestroyEvidence(string key)
        {
            
        }
    }
}
