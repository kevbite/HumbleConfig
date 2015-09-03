using System;
using System.Collections.Generic;

namespace HumbleConfig
{
    public class Configuration : IConfiguration
    {
        private readonly List<IConfigurationSource> _configurationSources = new List<IConfigurationSource>();
        
        public string[] GetAppSettings(string key)
        {
            foreach (var configurationSource in _configurationSources)
            {
                string[] values;
                if (configurationSource.TryGetAppSettings(key, out values))
                {
                    return values;
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
    }
}
