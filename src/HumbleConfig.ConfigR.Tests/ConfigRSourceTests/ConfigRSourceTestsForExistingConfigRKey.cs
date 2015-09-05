using ConfigR;
using HumbleConfig.Tests;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.ConfigR.Tests.ConfigRSourceTests
{
    public class ConfigRSourceTestsForExistingConfigRKey : ConfigurationSourceTestsForExistingKey<ConfigRSourceFactory>
    {

    }

    public class ConfigRSourceFactory : IConfigurationSourceFactory
    {
        public IConfigurationSource Create(string key, string value)
        {
            var config = Config.Global;
            config.Add(key, value);
            return new ConfigRSource(config);
        }
    }
}
