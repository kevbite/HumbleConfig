using System;
using NUnit.Framework;

namespace HumbleConfig.Tests.ConfigurationTests
{
    public class ConfigurationTestsForNoSourcesForNoneNullableValues<TValue> : NoneNullableTests<TValue>
    {
        private Configuration _configuration;
        private TValue _value;
        private ArgumentException _exception;

        [TestFixtureSetUp]
        public void GivenAConfigurationWithNoSourcesLoaded()
        {
            _configuration = new Configuration();
        }

        [SetUp]
        public void WhenGettingAnAppSetting()
        {
            try
            {
                _value = _configuration.GetAppSetting<TValue>("key");
            }
            catch (ArgumentException ex)
            {
                _exception = ex;
            }
        }

        [Test]
        public void ThenAnExceptionIsThrown()
        {
            Assert.That(_exception, Is.Not.Null);
        }
    }
}