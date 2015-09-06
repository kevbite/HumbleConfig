
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HumbleConfig.ConfigurationManager
{
    public class ConfigurationManagerSource : IConfigurationSource
    {
        public Task<bool> TryGetAppSetting<T>(string key, out T value)
        {
            var configValue = System.Configuration.ConfigurationManager.AppSettings[key];

            if (configValue == null)
            {
                value = default(T);
                return Task.FromResult(false);
            }
            else
            {
                var valueType = typeof(T);
                valueType = Nullable.GetUnderlyingType(valueType) ?? valueType;

                value = (T)Convert.ChangeType(configValue, valueType);
                return Task.FromResult(true);
            }
        }
    }
}
