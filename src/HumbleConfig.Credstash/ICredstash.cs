using System.Collections.Generic;
using System.Threading.Tasks;
using Narochno.Primitives;

namespace HumbleConfig.Credstash
{
    public interface ICredstash
    {
        Task<Optional<string>> GetSecretAsync(string name, string version = null, Dictionary<string, string> encryptionContext = null, bool throwOnInvalidCipherTextException = true);
    }
}