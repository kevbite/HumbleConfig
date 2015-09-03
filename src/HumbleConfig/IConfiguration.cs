namespace HumbleConfig
{
    public interface IConfiguration
    {
        string GetAppSetting(string key);

        string GetConnectionString(string key);
    }
}