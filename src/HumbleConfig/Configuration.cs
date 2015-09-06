using System;
using System.Collections.Generic;
using HumbleConfig.KeyFormatters;

namespace HumbleConfig
{
    public class Configuration : IConfiguration
    {
        private readonly List<IConfigurationSource> _configurationSources = new List<IConfigurationSource>();
        private IKeyFormatter _keyFormatter = new DefaultKeyFormatter();

        public TValue GetAppSetting<TValue>(string key)
        {
            var formattedKey = _keyFormatter.FormatKey(key);
            foreach (var configurationSource in _configurationSources)
            {
                TValue value;
                if (configurationSource.TryGetAppSetting(formattedKey, out value).Result)
                {
                    return value;
                }
            }

            var valueType = typeof (TValue);

            if(valueType.IsClass || valueType.IsGenericType && valueType.GetGenericTypeDefinition() == typeof (Nullable<>))
            {
                return default(TValue);
            }

            throw new ArgumentException($"No value could be found for the given key of {key}", nameof(key));
        }


        public string GetConnectionString(string key)
        {
            throw new NotImplementedException();
        }

        public void AddConfigurationSource(IConfigurationSource configurationSource)
        {
            _configurationSources.Add(configurationSource);
        }

        public void SetKeyFormatter(IKeyFormatter keyFormatter)
        {
            _keyFormatter = keyFormatter;
        }
    }
}
