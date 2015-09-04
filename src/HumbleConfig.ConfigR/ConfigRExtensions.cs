using ConfigR;

namespace HumbleConfig.ConfigR
{
    public static class ConfigRExtensions
    {
        public static Configuration AddConfigR(this Configuration configuration)
        {
            return configuration.AddConfigR(Config.Global);
        }

        public static Configuration AddConfigR(this Configuration configuration, IConfig config)
        {
            configuration.AddConfigurationSource(new ConfigRSource(config));

            return configuration;
        }
    }
}
