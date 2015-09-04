
using System.Linq;

namespace HumbleConfig.ConfigurationManager
{
    public class ConfigurationManagerSource : IConfigurationSource
    {
        public bool TryGetAppSetting(string key, out string value)
        {
            value = System.Configuration.ConfigurationManager.AppSettings[key];

            return value != null;
        }
    }
}
