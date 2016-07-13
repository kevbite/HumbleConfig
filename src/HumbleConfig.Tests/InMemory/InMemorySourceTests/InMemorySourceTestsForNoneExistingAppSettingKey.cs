using System.Collections.Generic;
using HumbleConfig.InMemory;
using NUnit.Framework;

namespace HumbleConfig.Tests.InMemory.InMemorySourceTests
{
    [TestFixtureSource(typeof(NonNullableTestFixtureCases))]
    [TestFixtureSource(typeof(NullableTestFixtureCases))]
    public class InMemorySourceTestsForNoneExistingAppSettingKey<TValue> : ConfigurationSourceTestsForNoneExistingKey<TValue>
    {
        protected override IConfigurationSource CreateConfigurationSource()
        {
            return new InMemorySource(new Dictionary<string, object>());
        }
    }
}
