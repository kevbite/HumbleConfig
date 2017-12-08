using System;
using System.Threading;
using System.Threading.Tasks;

namespace HumbleConfig
{
    public class ConfigurationSourceWrapper : IConfigurationSourceConfigurator
    {
        private readonly Configuration _configuration;

        public ConfigurationSourceWrapper(Configuration configuration, IConfigurationSource configurationSource)
        {
            _configuration = configuration;
            Source = configurationSource;
        }

        public IConfigurationSource Source { get; private set; }

        public IConfigurationSourceConfigurator WrapSource(Func<IConfigurationSource, IConfigurationSource> func)
        {
            Source = func(Source);

            return this;
        }

        public IConfigurationSourceConfigurator AddConfigurationSource(IConfigurationSource configurationSource)
        {
            return _configuration.AddConfigurationSource(configurationSource);
        }

        public Task<TValue> GetAppSettingAsync<TValue>(string key, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _configuration.GetAppSettingAsync<TValue>(key, cancellationToken);
        }

        public IConfiguration GetConfiguration()
        {
            return _configuration;
        }
    }
}