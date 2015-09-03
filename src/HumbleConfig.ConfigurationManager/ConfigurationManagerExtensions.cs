namespace HumbleConfig.ConfigurationManager
{
    public static class ConfigurationManagerExtensions
    {
        public static Configuration AddEnvironmentVariables(this Configuration configuration)
        {
            configuration.AddConfigurationSource(new ConfigurationManagerSource());

            return configuration;
        }
    }
}
