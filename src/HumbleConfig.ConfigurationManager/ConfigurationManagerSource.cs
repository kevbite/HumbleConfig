﻿
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HumbleConfig.ConfigurationManager
{
    public class ConfigurationManagerSource : IConfigurationSource
    {
        public Task<ConfigurationSourceResult<TValue>> GetAppSettingAsync<TValue>(string key, CancellationToken cancellationToken = default(CancellationToken))
        {
            var configValue = System.Configuration.ConfigurationManager.AppSettings[key];

            if (configValue == null)
            {
                return Task.FromResult(ConfigurationSourceResult<TValue>.FailedResult());
            }
            else
            {
                var valueType = typeof(TValue);
                valueType = Nullable.GetUnderlyingType(valueType) ?? valueType;

                var value = (TValue)Convert.ChangeType(configValue, valueType);
                return Task.FromResult(ConfigurationSourceResult<TValue>.SuccessResult(value));
            }
        }
    }
}
