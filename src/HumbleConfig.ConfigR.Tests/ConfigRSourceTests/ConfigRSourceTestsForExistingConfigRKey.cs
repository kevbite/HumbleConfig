using ConfigR;
using HumbleConfig.Tests;

namespace HumbleConfig.ConfigR.Tests.ConfigRSourceTests
{
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
