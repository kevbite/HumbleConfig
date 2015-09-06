using System.Collections.Generic;
using HumbleConfig.InMemory;

namespace HumbleConfig.Tests.InMemory.InMemorySourceTests
{
    public class InMemorySourceTestsForNoneExistingAppSettingKey<TValue> : ConfigurationSourceTestsForNoneExistingKey<TValue>
    {
        protected override IConfigurationSource CreateConfigurationSource()
        {
            return new InMemorySource(new Dictionary<string, object>());
        }
    }
}
