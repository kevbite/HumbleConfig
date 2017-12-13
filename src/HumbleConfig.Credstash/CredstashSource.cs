using System;
using System.Threading;
using System.Threading.Tasks;
using Narochno.Credstash;

namespace HumbleConfig.Credstash
{
    public class CredstashSource : IConfigurationSource
    {
        private readonly ICredstash _credstash;

        public CredstashSource(ICredstash credstash)
        {
            _credstash = credstash;
        }

        public async Task<ConfigurationSourceResult<TValue>> GetAppSettingAsync<TValue>(string key, CancellationToken cancellationToken = default(CancellationToken))
        {
            var credstashValue = await _credstash.GetSecretAsync(key)
                .ConfigureAwait(false);

            if (credstashValue.HasNoValue)
            {
                return ConfigurationSourceResult<TValue>.FailedResult();
            }
            else
            {
                var valueType = typeof(TValue);
                valueType = Nullable.GetUnderlyingType(valueType) ?? valueType;

                var value = (TValue)Convert.ChangeType(credstashValue.Value, valueType);

                return ConfigurationSourceResult<TValue>.SuccessResult(value);
            }
        }
    }
}
