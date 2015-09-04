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

        public bool TryGetAppSetting<T>(string key, out T value)
        {
            object temp;
            var result = _config.TryGetValue(key, out temp);

            value = result ? (T)temp : default(T);

            return result;
        }
    }
}
