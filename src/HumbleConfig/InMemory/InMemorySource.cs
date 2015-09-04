using System;
using System.Collections.Generic;

namespace HumbleConfig.InMemory
{
    public class InMemorySource : IConfigurationSource
    {
        private readonly IDictionary<string, string> _appSettings;

        public InMemorySource(IDictionary<string, string> appSettings)
        {
            _appSettings = appSettings;
        }

        public bool TryGetAppSetting(string key, out string value)
        {
            return _appSettings.TryGetValue(key, out value);
        }
    }
}

