namespace HumbleConfig
{
    public interface IConfiguration
    {
        string[] GetAppSettings(string key);

        string GetConnectionString(string key);
    }
}