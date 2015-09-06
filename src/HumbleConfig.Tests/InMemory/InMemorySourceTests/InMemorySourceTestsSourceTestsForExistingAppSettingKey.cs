using System.Collections.Generic;
using HumbleConfig.InMemory;
using NUnit.Framework;

namespace HumbleConfig.Tests.InMemory.InMemorySourceTests
{
    public class InMemorySourceTestsSourceTestsForExistingAppSettingKey<TValue> : ConfigurationSourceTestsForExistingKey<TValue>
    {
        protected override IConfigurationSource GivenConfigurationSourceWithExistingRKey(string key, TValue value)
        {
            var appSettings = new Dictionary<string, object>()
            {
                {key, value}
            };

            return new InMemorySource(appSettings);
        }
    }
}
