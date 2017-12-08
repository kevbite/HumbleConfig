using System;

namespace HumbleConfig
{
    public class ConfigurationSourceWrapper : IConfigurationSourceConfigurator
    {
        private readonly IConfigurationConfigurator _configurationConfigurator;

        public ConfigurationSourceWrapper(IConfigurationConfigurator configurationConfigurator, IConfigurationSource configurationSource)
        {
            _configurationConfigurator = configurationConfigurator;
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
            return _configurationConfigurator.AddConfigurationSource(configurationSource);
        }
    }
}