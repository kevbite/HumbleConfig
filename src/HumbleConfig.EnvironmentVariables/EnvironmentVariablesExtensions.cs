namespace HumbleConfig.EnvironmentVariables
{
    public static class EnvironmentVariablesExtensions
    {
        public static Configuration AddEnvironmentVariables(this Configuration configuration)
        {
            configuration.AddConfigurationSource(new EnvironmentVariablesSource());

            return configuration;
        }
    }
}
