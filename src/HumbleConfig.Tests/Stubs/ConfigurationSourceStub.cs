using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HumbleConfig.Tests.Stubs
{
    public class ConfigurationSourceStub : IConfigurationSource
    {
        public IDictionary<string, object> AppSettings { get; } = new Dictionary<string, object>();
        
        
        public Task<ConfigurationSourceResult<TValue>> GetAppSettingAsync<TValue>(string key, CancellationToken cancellationToken = default(CancellationToken))
        {
            object temp;
            var result = AppSettings.TryGetValue(key, out temp);

            var sourceResult = result ? ConfigurationSourceResult<TValue>.SuccessResult((TValue)temp)
                            : ConfigurationSourceResult<TValue>.FailedResult();

            return Task.FromResult(sourceResult);
        }
    }
}
