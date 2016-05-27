using System;
using NUnit.Framework;

namespace HumbleConfig.Tests.ConfigurationTests
{
    [TestFixtureSource(typeof(NonNullableTestFixtureCases))]
    public class ConfigurationTestsForNoSourcesForNoneNullableValues<TValue>
    {
        private Configuration _configuration;
        private TValue _value;
        private ArgumentException _exception;

        [OneTimeSetUp]
        public void GivenAConfigurationWithNoSourcesLoaded()
        {
            _configuration = new Configuration();
        }

        [SetUp]
        public void WhenGettingAnAppSetting()
        {
            try
            {
                _value = _configuration.GetAppSettingAsync<TValue>("key").Result;
            }
            catch (ArgumentException ex)
            {
                _exception = ex;
            }
            catch (AggregateException ex)
            {
                var argumentException = ex.InnerException as ArgumentException;
                if (argumentException != null)
                {
                    _exception = argumentException;

                }
            }
        }

        [Test]
        public void ThenAnExceptionIsThrown()
        {
            Assert.That(_exception, Is.Not.Null);
        }
    }
}