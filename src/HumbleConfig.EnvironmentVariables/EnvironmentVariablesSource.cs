using System;

namespace HumbleConfig.EnvironmentVariables
{
    public class EnvironmentVariablesSource : IConfigurationSource
    {
        public bool TryGetAppSetting(string key, out string value)
        {
            value = Environment.GetEnvironmentVariable(key);

            return value != null;
        }
    }
}
