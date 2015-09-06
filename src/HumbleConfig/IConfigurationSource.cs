using System.Threading.Tasks;

namespace HumbleConfig
{
    public interface IConfigurationSource
    {
        Task<ConfigurationSourceResult<TValue>> TryGetAppSetting<TValue>(string key);
    }
}