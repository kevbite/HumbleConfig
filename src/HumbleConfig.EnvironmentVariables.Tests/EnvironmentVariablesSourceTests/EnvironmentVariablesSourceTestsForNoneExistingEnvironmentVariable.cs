using System;
using HumbleConfig.Tests;
using HumbleConfig.Tests.Stubs;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.EnvironmentVariables.Tests.EnvironmentVariablesSourceTests
{
    [TestFixture]
    public class EnvironmentVariablesSourceTestsForNoneExistingEnvironmentVariable<TValue> : ConfigurationSourceTestsForNoneExistingKey<TValue>
    {
        protected override IConfigurationSource CreateConfigurationSource()
        {
            return new EnvironmentVariablesSource();
        }
    }
}
