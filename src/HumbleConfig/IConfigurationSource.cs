namespace HumbleConfig
{
    public interface IConfigurationSource
    {
        bool TryGetAppSetting(string key, out string value);
    }
}