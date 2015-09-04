using System.Collections.Generic;

namespace HumbleConfig.Tests.Stubs
{
    public class ConfigurationSourceStub : IConfigurationSource
    {
        public IDictionary<string, string> AppSettings { get; } = new Dictionary<string, string>();

        public IDictionary<string, string> ConnectionStrings { get; } = new Dictionary<string, string>();
        
        public bool TryGetAppSetting(string key, out string value)
        {
            return AppSettings.TryGetValue(key, out value);
        }

        public bool TryGetConnectionString(string key, out string value)
        {
            return ConnectionStrings.TryGetValue(key, out value);
        }
    }
}
