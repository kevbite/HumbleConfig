using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumbleConfig.Tests.Stubs
{
    public class ConfigurationSourceStub : IConfigurationSource
    {
        public IDictionary<string, object> AppSettings { get; } = new Dictionary<string, object>();
        
        
        public Task<ConfigurationSourceResult<TValue>> TryGetAppSetting<TValue>(string key)
        {
            object temp;
            var result = AppSettings.TryGetValue(key, out temp);

            var sourceResult = result ? ConfigurationSourceResult<TValue>.SuccessResult((TValue)temp)
                            : ConfigurationSourceResult<TValue>.FailedResult();

            return Task.FromResult(sourceResult);
        }
    }
}
