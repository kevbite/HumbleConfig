using System.Threading.Tasks;
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

        public Task<bool>TryGetAppSetting<T>(string key, out T value)
        {
            object temp;
            var result = _config.TryGetValue(key, out temp);

            value = result ? (T)temp : default(T);

            return Task.FromResult(result);
        }
    }
}
