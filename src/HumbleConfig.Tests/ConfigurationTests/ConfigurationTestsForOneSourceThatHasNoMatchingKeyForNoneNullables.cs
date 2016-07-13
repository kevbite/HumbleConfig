using System;
using HumbleConfig.Tests.Stubs;
using NUnit.Framework;

namespace HumbleConfig.Tests.ConfigurationTests
{
    [TestFixtureSource(typeof(NonNullableTestFixtureCases))]
    public class ConfigurationTestsForOneSourceThatHasNoMatchingKeyForNoneNullables<TValue>
    {
        private Configuration _configuration;
        private TValue _value;
        private ArgumentException _exception;

        [OneTimeSetUp]
        public void GivenAConfigurationWithOneSourceThatHasNoMatchingKey()
        {
            _configuration = new Configuration();

            var source = new ConfigurationSourceStub();
            _configuration.AddConfigurationSource(source);
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