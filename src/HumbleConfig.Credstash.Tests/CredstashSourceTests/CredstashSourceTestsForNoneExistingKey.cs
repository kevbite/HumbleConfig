using HumbleConfig.Tests;
using Moq;
using NUnit.Framework;

namespace HumbleConfig.Credstash.Tests.CredstashSourceTests
{
    [TestFixtureSource(typeof(NonNullableTestFixtureCases))]
    [TestFixtureSource(typeof(NullableTestFixtureCases))]
    public class CredstashSourceTestsForNoneExistingKey<TValue> : ConfigurationSourceTestsForNoneExistingKey<TValue>
    {
        protected override IConfigurationSource CreateConfigurationSource()
        {
            return new CredstashSource(new Mock<ICredstash>().Object);
        }
    }
}
