using System.Configuration;
using HumbleConfig.Tests;
using NUnit.Framework;

namespace HumbleConfig.ConfigurationManager.Tests.ConfigurationManagerSourceTests
{
    [TestFixture]
    public class ConfigurationManagerSourceTestsForExistingAppSettingKey<TValue> : ConfigurationSourceTestsForExistingKey<TValue, ConfigurationManagerFactory>
    {
       
    }

    public class ConfigurationManagerFactory : IConfigurationSourceFactory
    {
        public IConfigurationSource Create<TValue>(string key, TValue value)
        {
            var config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettingsSection = (AppSettingsSection)config.GetSection("appSettings");
            appSettingsSection.Settings.Clear();
            appSettingsSection.Settings.Add(key, value.ToString());
            config.Save();
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");

            return new ConfigurationManagerSource();
        }
    }
}
