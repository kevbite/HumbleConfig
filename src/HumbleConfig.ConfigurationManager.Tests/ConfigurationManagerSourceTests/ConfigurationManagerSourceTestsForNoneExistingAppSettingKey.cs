using HumbleConfig.Tests;
using NUnit.Framework;

namespace HumbleConfig.ConfigurationManager.Tests.ConfigurationManagerSourceTests
{
    public class ConfigurationManagerSourceTestsForNoneExistingAppSettingKey<TValue> : ConfigurationSourceTestsForNoneExistingKey<TValue>
    {
        protected override IConfigurationSource CreateConfigurationSource()
        {
            return new ConfigurationManagerSource();
        }
    }
}
