using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.Tests
{
   /* [TestFixture(typeof(bool))]
    [TestFixture(typeof(byte))]
    [TestFixture(typeof(char))]
    [TestFixture(typeof(decimal))]
    [TestFixture(typeof(double))]
    [TestFixture(typeof(float))]
    [TestFixture(typeof(int))]
    [TestFixture(typeof(long))]
    [TestFixture(typeof(sbyte))]
    [TestFixture(typeof(short))]*/
    //[TestFixture(typeof(string))]
    [TestFixture]
    public abstract class ConfigurationSourceTestsForExistingKey<TConfigurationSourceFactory> where TConfigurationSourceFactory : IConfigurationSourceFactory, new ()
    {
        private IConfigurationSource _source;
        private bool _result;
        private string _value;
        private readonly Fixture _fixture = new Fixture();
        private string _key;
        private string _expectedValue;

        [TestFixtureSetUp]
        public void ConfigRSourceTestsWithExistingConfigRKey()
        {
            _key = _fixture.Create<string>();
            _expectedValue = _fixture.Create<string>();
            
            var sourceFactory = new TConfigurationSourceFactory();
            _source = sourceFactory.Create(_key, _expectedValue);
        }

        [SetUp]
        public void WhenTryingToGetTheAppSettings()
        {
            _result = _source.TryGetAppSetting(_key, out _value);
        }

        [Test]
        public void ThenTheCorrectValueIsReturned()
        {
            Assert.That(_value, Is.EqualTo(_expectedValue));
        }

        [Test]
        public void ThenTheResultIsTrue()
        {
            Assert.That(_result, Is.True);
        }
    }

    public interface IConfigurationSourceFactory
    {
        IConfigurationSource Create(string key, string value);
    }
}
