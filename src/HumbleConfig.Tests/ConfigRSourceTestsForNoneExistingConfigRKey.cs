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
        private bool _result;
        private TValue _value;

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
            _result = _source.TryGetAppSetting(key, out _value);
        }

        [Test]
        public void ThenNullIsReturned()
        {
            Assert.That(_value, Is.EqualTo(default(TValue)));
        }

        [Test]
        public void ThenTheResultIsFalse()
        {
            Assert.That(_result, Is.False);
        }
    }
}
