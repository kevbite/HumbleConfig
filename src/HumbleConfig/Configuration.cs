using System;
using System.Collections.Generic;
using HumbleConfig.KeyFormatters;

namespace HumbleConfig
{
    public class Configuration : IConfiguration
    {
        private readonly List<IConfigurationSource> _configurationSources = new List<IConfigurationSource>();
        private IKeyFormatter _keyFormatter = new DefaultKeyFormatter();

        public string GetAppSetting(string key)
        {
            var formattedKey = _keyFormatter.FormatKey(key);
            foreach (var configurationSource in _configurationSources)
            {
                string value;
                if (configurationSource.TryGetAppSetting(formattedKey, out value))
                {
                    return value;
                }
            }

            return null;
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
