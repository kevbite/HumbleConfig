using System;

namespace HumbleConfig.EnvironmentVariables
{
    public class EnvironmentVariablesSource : IConfigurationSource
    {
        public bool TryGetAppSetting<T>(string key, out T value)
        {
            var environmentValue = Environment.GetEnvironmentVariable(key);

            if (environmentValue == null)
            {
                value = default(T);
                return false;
            }
            else
            {
                value = (T)Convert.ChangeType(environmentValue, typeof(T));
                return true;
            }
        }
    }
}
