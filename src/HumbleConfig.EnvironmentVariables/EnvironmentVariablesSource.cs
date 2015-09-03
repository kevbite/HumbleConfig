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

        public bool TryGetConnectionString(string key, out string value)
        {
            throw new System.NotImplementedException();
        }
    }
}
