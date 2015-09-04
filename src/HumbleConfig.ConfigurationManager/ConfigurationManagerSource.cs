
using System;
using System.Linq;

namespace HumbleConfig.ConfigurationManager
{
    public class ConfigurationManagerSource : IConfigurationSource
    {
        public bool TryGetAppSetting<T>(string key, out T value)
        {
            var configValue = System.Configuration.ConfigurationManager.AppSettings[key];

            value = (T) Convert.ChangeType(configValue, typeof (T));

            return value != null;
        }
    }
}
