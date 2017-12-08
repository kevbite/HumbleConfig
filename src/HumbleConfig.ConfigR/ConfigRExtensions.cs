using ConfigR;

namespace HumbleConfig.ConfigR
{
    public static class ConfigRExtensions
    {
        public static IConfigurationSourceConfigurator AddConfigR(this IConfigurationConfigurator configuration)
        {
            return configuration.AddConfigR(Config.Global);
        }

        public static IConfigurationSourceConfigurator AddConfigR(this IConfigurationConfigurator configuration, IConfig config)
        {
            return configuration.AddConfigurationSource(new ConfigRSource(config));
        }
    }
}
