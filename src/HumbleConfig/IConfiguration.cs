namespace HumbleConfig
{
    public interface IConfiguration
    {
        TValue GetAppSetting<TValue>(string key);
    }
}