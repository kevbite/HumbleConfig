using ConfigR;
using HumbleConfig.Tests;
using NUnit.Framework;

namespace HumbleConfig.ConfigR.Tests.ConfigRSourceTests
{
    [TestFixtureSource(typeof(NonNullableTestFixtureCases))]
    [TestFixtureSource(typeof(NullableTestFixtureCases))]
    public class ConfigRSourceTestsForNoneExistingConfigRKey<TValue> : ConfigurationSourceTestsForNoneExistingKey<TValue>
    {
        protected override IConfigurationSource CreateConfigurationSource()
        {
            return new ConfigRSource(Config.Global);
        }
    }
}
