using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.KeyManagementService;
using HumbleConfig.Tests;
using Moq;
using Narochno.Credstash;
using Narochno.Primitives;
using NUnit.Framework;

namespace HumbleConfig.Credstash.Tests.CredstashSourceTests
{
    [TestFixtureSource(typeof(NonNullableTestFixtureCases))]
    [TestFixtureSource(typeof(NullableTestFixtureCases))]
    public class CredstashSourceTestsForExistingKey<TValue> : ConfigurationSourceTestsForExistingKey<TValue>
    {
        protected override IConfigurationSource GivenConfigurationSourceWithExistingRKey(string key, TValue value)
        {
            var mock = new Mock<ICredstash>();
            mock.Setup(x => x.GetSecretAsync(key, null, null, true))
                .ReturnsAsync(new Optional<string>(value.ToString()));

            return new CredstashSource(mock.Object);
        }
    }
}
