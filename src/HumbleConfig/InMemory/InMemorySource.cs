using System;
using System.Collections.Generic;

namespace HumbleConfig.InMemory
{
    public class InMemorySource : IConfigurationSource
    {
        private readonly IDictionary<string, object> _appSettings;

        public InMemorySource(IDictionary<string, object> appSettings)
        {
            _appSettings = appSettings;
        }

        public bool TryGetAppSetting<T>(string key, out T value)
        {
            object temp;
            var result = _appSettings.TryGetValue(key, out temp);

            value = result ? (T) temp : default(T);

            return result;
        }
    }
}

