using HumbleConfig.Tests;
using Moq;
using Narochno.Primitives;
using NUnit.Framework;

namespace HumbleConfig.Credstash.Tests.CredstashSourceTests
{
    [TestFixtureSource(typeof(NonNullableTestFixtureCases))]
    [TestFixtureSource(typeof(NullableTestFixtureCases))]
    public class CredstashSourceTestsForNoneExistingKey<TValue> : ConfigurationSourceTestsForNoneExistingKey<TValue>
    {
        protected override IConfigurationSource CreateConfigurationSource()
        {
            var credstash = new Mock<ICredstash>();
            credstash.Setup(x => x.GetSecretAsync(It.IsAny<string>(), null, null, true))
                .ReturnsAsync(new Optional<string>(null));

            return new CredstashSource(credstash.Object);
        }
    }
}
