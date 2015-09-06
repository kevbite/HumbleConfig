using System.Threading;
using System.Threading.Tasks;

namespace HumbleConfig
{
    public interface IConfiguration
    {
        Task<TValue> GetAppSettingAsync<TValue>(string key, CancellationToken cancellationToken = default(CancellationToken));
    }
}