namespace HumbleConfig
{
    public interface IConfigurationSource
    {
        bool TryGetAppSetting<T>(string key, out T value);
    }
}