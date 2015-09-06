using System;
using System.Threading.Tasks;

namespace HumbleConfig.EnvironmentVariables
{
    public class EnvironmentVariablesSource : IConfigurationSource
    {
        public Task<bool> TryGetAppSetting<T>(string key, out T value)
        {
            var environmentValue = Environment.GetEnvironmentVariable(key);

            if (environmentValue == null)
            {
                value = default(T);
                return Task.FromResult(false);
            }
            else
            {
                var valueType = typeof (T);
                valueType = Nullable.GetUnderlyingType(valueType) ?? valueType;

                value = (T) Convert.ChangeType(environmentValue, valueType);

                return Task.FromResult(true);
            }
        }
    }
}
