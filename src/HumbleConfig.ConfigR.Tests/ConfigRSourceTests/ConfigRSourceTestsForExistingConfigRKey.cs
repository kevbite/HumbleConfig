using ConfigR;
using HumbleConfig.Tests;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.ConfigR.Tests.ConfigRSourceTests
{
    public class ConfigRSourceTestsForExistingConfigRKey<TValue> : ConfigurationSourceTestsForExistingKey<TValue, ConfigRSourceFactory>
    {

    }

    public class ConfigRSourceFactory : IConfigurationSourceFactory
    {
        public IConfigurationSource Create<TValue>(string key, TValue value)
        {
            var config = Config.Global;
            config.Add(key, value);
            return new ConfigRSource(config);
        }
    }
}
