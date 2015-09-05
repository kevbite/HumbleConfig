using ConfigR;
using HumbleConfig.Tests;

namespace HumbleConfig.ConfigR.Tests.ConfigRSourceTests
{
    public class ConfigRSourceTestsForExistingConfigRKey<TValue> : ConfigurationSourceTestsForExistingKey<TValue, ConfigRSourceFactory>
    {

    }

    public class ConfigRSourceFactory : IConfigurationSourceFactory
    {
        public IConfigurationSource Create()
        {
            return new ConfigRSource(Config.Global);
        }

        public IConfigurationSource Create(IConfig config)
        {
            return new ConfigRSource(config);
        }

        public IConfigurationSource Create<TValue>(string key, TValue value)
        {
            var config = Config.Global;
            config.Add(key, value);

            return Create(config);
        }
    }
}
