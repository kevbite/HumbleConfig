using System;
using System.Threading;
using System.Threading.Tasks;

namespace HumbleConfig.EnvironmentVariables
{
    public class EnvironmentVariablesSource : IConfigurationSource
    {
        public Task<ConfigurationSourceResult<TValue>> GetAppSettingAsync<TValue>(string key, CancellationToken cancellationToken = default(CancellationToken))
        {
            var environmentValue = Environment.GetEnvironmentVariable(key);

            if (environmentValue == null)
            {
                return Task.FromResult(ConfigurationSourceResult<TValue>.FailedResult());
            }
            else
            {
                var valueType = typeof (TValue);
                valueType = Nullable.GetUnderlyingType(valueType) ?? valueType;

                var value = (TValue) Convert.ChangeType(environmentValue, valueType);

                return Task.FromResult(ConfigurationSourceResult<TValue>.SuccessResult(value));
            }
        }
    }
}
