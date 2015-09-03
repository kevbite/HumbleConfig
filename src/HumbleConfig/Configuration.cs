using System;
using System.Collections.Generic;

namespace HumbleConfig
{
    public class Configuration : IConfiguration
    {
        private readonly List<IConfigurationSource> _configurationSources = new List<IConfigurationSource>();
        
        public string GetAppSetting(string key)
        {
            foreach (var configurationSource in _configurationSources)
            {
                string value;
                if (configurationSource.TryGetAppSetting(key, out value))
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
    }
}
