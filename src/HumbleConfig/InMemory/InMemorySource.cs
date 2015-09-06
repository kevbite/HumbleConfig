using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HumbleConfig.InMemory
{
    public class InMemorySource : IConfigurationSource
    {
        private readonly IDictionary<string, object> _appSettings;

        public InMemorySource(IDictionary<string, object> appSettings)
        {
            _appSettings = appSettings;
        }

        public Task<ConfigurationSourceResult<TValue>> GetAppSettingAsync<TValue>(string key, CancellationToken cancellationToken = default(CancellationToken))
        {
            object temp;
            var result = _appSettings.TryGetValue(key, out temp);

            var sourceResult =  result ? ConfigurationSourceResult<TValue>.SuccessResult((TValue) temp)
                                        : ConfigurationSourceResult<TValue>.FailedResult();

            return Task.FromResult(sourceResult);
        }
    }
}

