using System.Collections.Generic;

namespace HumbleConfig.Tests.Stubs
{
    public class ConfigurationSourceStub : IConfigurationSource
    {
        public IDictionary<string, object> AppSettings { get; } = new Dictionary<string, object>();
        
        
        public bool TryGetAppSetting<T>(string key, out T value)
        {
            object temp;
            var result = AppSettings.TryGetValue(key, out temp);

            value = result ? (T) temp : default(T);

            return result;
        }
    }
}
