using System.Threading;
using System.Threading.Tasks;

namespace HumbleConfig
{
    public interface IConfigurationSource
    {
        Task<ConfigurationSourceResult<TValue>> GetAppSettingAsync<TValue>(string key, CancellationToken cancellationToken = default(CancellationToken));
    }
}