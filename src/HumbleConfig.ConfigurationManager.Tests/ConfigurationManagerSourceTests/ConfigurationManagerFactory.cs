using System.Configuration;
using HumbleConfig.Tests;

namespace HumbleConfig.ConfigurationManager.Tests.ConfigurationManagerSourceTests
{
    public class ConfigurationManagerFactory : IConfigurationSourceFactory
    {
        public IConfigurationSource Create()
        {
            return new ConfigurationManagerSource();
        }

        public IConfigurationSource Create<TValue>(string key, TValue value)
        {
            var config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var appSettingsSection = (AppSettingsSection)config.GetSection("appSettings");
            appSettingsSection.Settings.Clear();
            appSettingsSection.Settings.Add(key, value.ToString());
            config.Save();
            System.Configuration.ConfigurationManager.RefreshSection("appSettings");

            return Create();
        }
    }
}