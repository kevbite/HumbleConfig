using ConfigR;
using HumbleConfig.Tests;
using NUnit.Framework;

namespace HumbleConfig.ConfigR.Tests.ConfigRSourceTests
{
    [TestFixtureSource(typeof(NonNullableTestFixtureCases))]
    [TestFixtureSource(typeof(NullableTestFixtureCases))]
    public class ConfigRSourceTestsForExistingConfigRKey<TValue> : ConfigurationSourceTestsForExistingKey<TValue>
    {
        protected override IConfigurationSource GivenConfigurationSourceWithExistingRKey(string key, TValue value)
        {
            var config = Config.Global;
            config.Add(key, value);
            return new ConfigRSource(config);   
        }
    }
}
