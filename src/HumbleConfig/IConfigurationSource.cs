using System.Threading.Tasks;

namespace HumbleConfig
{
    public interface IConfigurationSource
    {
        Task<bool> TryGetAppSetting<T>(string key, out T value);
    }
}