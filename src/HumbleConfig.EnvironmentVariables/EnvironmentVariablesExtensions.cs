namespace HumbleConfig.EnvironmentVariables
{
    public static class EnvironmentVariablesExtensions
    {
        public static IConfigurationSourceConfigurator AddEnvironmentVariables(this IConfigurationConfigurator configuration)
        {
            return configuration.AddConfigurationSource(new EnvironmentVariablesSource());
        }
    }
}