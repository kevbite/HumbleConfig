namespace HumbleConfig
{
    public interface IConfigurationConfigurator
    {
        IConfigurationSourceConfigurator AddConfigurationSource(IConfigurationSource configurationSource);

        IConfiguration GetConfiguration();
    }
}