using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumbleConfig.KeyFormatters
{
    public class KeyFormatterConfigurationSourceDecorator : IConfigurationSource
    {
        private readonly IConfigurationSource _inner;
        private readonly IKeyFormatter _keyFormatter;

        public KeyFormatterConfigurationSourceDecorator(IConfigurationSource inner, IKeyFormatter keyFormatter)
        {
            _inner = inner;
            _keyFormatter = keyFormatter;
        }
        public async Task<ConfigurationSourceResult<TValue>> GetAppSettingAsync<TValue>(string key, CancellationToken cancellationToken = default(CancellationToken))
        {
            key = _keyFormatter.FormatKey(key);

            return await _inner.GetAppSettingAsync<TValue>(key, cancellationToken).ConfigureAwait(false);
        }
    }
}
