namespace HumbleConfig.Tests
{
    public interface IConfigurationSourceFactory
    {
        IConfigurationSource Create();
        IConfigurationSource Create<TValue>(string key, TValue value);
    }
}