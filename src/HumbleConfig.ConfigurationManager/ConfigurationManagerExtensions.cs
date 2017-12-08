namespace HumbleConfig.ConfigurationManager
{
    public static class ConfigurationManagerExtensions
    {
        public static IConfigurationSourceConfigurator AddConfigurationManager(this IConfigurationConfigurator configuration)
        {
            return configuration.AddConfigurationSource(new ConfigurationManagerSource());
        }
    }
}
