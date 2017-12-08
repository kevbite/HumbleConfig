using System.Collections.Generic;

namespace HumbleConfig.InMemory
{
    public static class InMemoryExtensions
    {
        public static IConfigurationSourceConfigurator AddInMemory(this IConfigurationConfigurator configuration, IDictionary<string, object> appSettings)
        {
            return configuration.AddConfigurationSource(new InMemorySource(appSettings));
        }
    }
}
