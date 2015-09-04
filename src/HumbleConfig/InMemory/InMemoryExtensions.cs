using System.Collections.Generic;

namespace HumbleConfig.InMemory
{
    public static class InMemoryExtensions
    {
        public static Configuration AddInMemory(this Configuration configuration, IDictionary<string, object> appSettings)
        {
            configuration.AddConfigurationSource(new InMemorySource(appSettings));

            return configuration;
        }
    }
}
