using System.Collections.Generic;
using System.Threading.Tasks;
using Narochno.Primitives;

namespace HumbleConfig.Credstash
{
    public class CredstashWrapper : ICredstash
    {
        private readonly Narochno.Credstash.Credstash _credstash;

        public CredstashWrapper(Narochno.Credstash.Credstash credstash)
        {
            _credstash = credstash;
        }

        public Task<Optional<string>> GetSecretAsync(string name, string version = null, Dictionary<string, string> encryptionContext = null,
            bool throwOnInvalidCipherTextException = true)
        {
            return _credstash.GetSecretAsync(name, version, encryptionContext, throwOnInvalidCipherTextException);
        }
    }
}