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

        public Task<ConfigurationSourceResult<TValue>> TryGetAppSetting<TValue>(string key)
        {
            object temp;
            var result = _config.TryGetValue(key, out temp);

            var sourceResult = result ? ConfigurationSourceResult<TValue>.SuccessResult((TValue)temp)
                            : ConfigurationSourceResult<TValue>.FailedResult();

            return Task.FromResult(sourceResult);
        }
    }
}
