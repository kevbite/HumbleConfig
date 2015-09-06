using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.Tests
{
    public abstract class ConfigurationSourceTestsForNoneExistingKey<TValue, TConfigurationSourceFactory> : AllValueTests<TValue> where TConfigurationSourceFactory : IConfigurationSourceFactory, new()
    {
        private IConfigurationSource _source;
        private ConfigurationSourceResult<TValue> _result;

        [TestFixtureSetUp]
        public void ConfigRSourceTestsWithNoneExistingConfigRKey()
        {
            var factory = new TConfigurationSourceFactory();
            _source = factory.Create();
        }

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
        public void ThenTheResultKEyExistsIsFalse()
        {
            Assert.That(_result.KeyExists, Is.False);
        }
    }
}
