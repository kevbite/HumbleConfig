using System.Threading.Tasks;

namespace HumbleConfig
{
    public interface IConfiguration
    {
        Task<TValue> GetAppSetting<TValue>(string key);
    }
}