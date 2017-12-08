using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HumbleConfig.KeyFormatters;

namespace HumbleConfig
{
    public class Configuration : IConfigurationConfigurator, IConfiguration
    {
        private readonly List<ConfigurationSourceWrapper> _configurationSources = new List<ConfigurationSourceWrapper>();
        private IKeyFormatter _keyFormatter = new DefaultKeyFormatter();

        public async Task<TValue> GetAppSettingAsync<TValue>(string key, CancellationToken cancellationToken = default(CancellationToken))
        {
            var formattedKey = _keyFormatter.FormatKey(key);
            foreach (var configurationSource in _configurationSources)
            {
                var result = await configurationSource.Source.GetAppSettingAsync<TValue>(formattedKey, cancellationToken).ConfigureAwait(false);
                if (result.KeyExists)
                {
                    return result.Value;
                }
            }

            var valueType = typeof (TValue);

            if(valueType.IsClass || valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof (Nullable<>))
            {
                return default(TValue);
            }

            throw new ArgumentException($"No value could be found for the given key of {key}", nameof(key));
        }
        
        public IConfigurationSourceConfigurator AddConfigurationSource(IConfigurationSource configurationSource)
        {
            var wrapper = new ConfigurationSourceWrapper(this, configurationSource);

            _configurationSources.Add(wrapper);

            return wrapper;
        }

        public IConfiguration GetConfiguration()
        {
            return this;
        }

        public void SetKeyFormatter(IKeyFormatter keyFormatter)
        {
            _keyFormatter = keyFormatter;
        }
    }
}
