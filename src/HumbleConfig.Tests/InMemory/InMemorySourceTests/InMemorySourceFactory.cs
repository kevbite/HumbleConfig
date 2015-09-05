using System.Collections.Generic;
using HumbleConfig.InMemory;

namespace HumbleConfig.Tests.InMemory.InMemorySourceTests
{
    public class InMemorySourceFactory : IConfigurationSourceFactory
    {
        public IConfigurationSource Create()
        {
            return Create(new Dictionary<string, object>());
        }

        private IConfigurationSource Create(IDictionary<string, object> appSettings)
        {
            return new InMemorySource(appSettings);
        }

        public IConfigurationSource Create<TValue>(string key, TValue value)
        {
            return Create(new Dictionary<string, object>() {{key, value}});
        }
    }
}