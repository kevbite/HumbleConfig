using System;

namespace HumbleConfig.EnvironmentVariables
{
    public class EnvironmentVariablesSource : IConfigurationSource
    {
        public bool TryGetAppSetting<T>(string key, out T value)
        {
            var environmentValue = Environment.GetEnvironmentVariable(key);

            value = (T) Convert.ChangeType(environmentValue, typeof (T));

            return value != null;
        }
    }
}
