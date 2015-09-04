using ConfigR;

namespace HumbleConfig.ConfigR
{
    public class ConfigRSource : IConfigurationSource
    {
        private readonly IConfig _config;

        public ConfigRSource(IConfig config)
        {
            _config = config;
        }

        public bool TryGetAppSetting(string key, out string value)
        {
            return _config.TryGetValue(key, out value);
        }
    }
}
