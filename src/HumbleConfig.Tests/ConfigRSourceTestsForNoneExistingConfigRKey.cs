using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.Tests
{
    [TestFixture(typeof(bool))]
    [TestFixture(typeof(byte))]
    [TestFixture(typeof(char))]
    [TestFixture(typeof(decimal))]
    [TestFixture(typeof(double))]
    [TestFixture(typeof(float))]
    [TestFixture(typeof(int))]
    [TestFixture(typeof(long))]
    [TestFixture(typeof(sbyte))]
    [TestFixture(typeof(short))]
    [TestFixture(typeof(string))]
    public abstract class ConfigurationSourceTestsForNoneExistingKey<TValue, TConfigurationSourceFactory> where TConfigurationSourceFactory : IConfigurationSourceFactory, new()
    {
        private IConfigurationSource _source;
        private bool _result;
        private string _value;

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
            Assert.That(_value, Is.Null);
        }

        [Test]
        public void ThenTheResultIsFalse()
        {
            Assert.That(_result, Is.False);
        }
    }
}
