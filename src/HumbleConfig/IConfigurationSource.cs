namespace HumbleConfig
{
    public interface IConfigurationSource
    {
        bool TryGetAppSettings(string key, out string[] values);

        bool TryGetConnectionString(string key, out string value);
    }
}