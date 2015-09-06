using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.Tests
{
    public abstract class ConfigurationSourceTestsForNoneExistingKey<TValue> : AllValueTests<TValue>
    {
        private IConfigurationSource _source;
        private ConfigurationSourceResult<TValue> _result;

        [TestFixtureSetUp]
        public void GivenConfigurationSourceWithNoneExistingKey()
        {
            _source = CreateConfigurationSource();
        }

        protected abstract IConfigurationSource CreateConfigurationSource();

        [SetUp]
        public void WhenTryingToGetTheAppSettings()
        {
            var key = new Fixture().Create<string>();
            _result = _source.TryGetAppSetting<TValue>(key).Result;
        }

        [Test]
        public void ThenNullIsReturned()
        {
            Assert.That(_result.Value, Is.EqualTo(default(TValue)));
        }

        [Test]
        public void ThenTheResultKeyExistsIsFalse()
        {
            Assert.That(_result.KeyExists, Is.False);
        }
    }
}
