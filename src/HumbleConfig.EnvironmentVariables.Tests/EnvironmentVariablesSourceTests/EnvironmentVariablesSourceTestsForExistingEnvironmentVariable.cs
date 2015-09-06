using System;
using System.Net.Http.Headers;
using HumbleConfig.Tests;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.EnvironmentVariables.Tests.EnvironmentVariablesSourceTests
{
    public class EnvironmentVariablesSourceTestsForExistingEnvironmentVariable<TValue> : ConfigurationSourceTestsForExistingKey<TValue>
    {
        protected override IConfigurationSource GivenConfigurationSourceWithExistingRKey(string key, TValue value)
        {
            Environment.SetEnvironmentVariable(key, value.ToString());

            return new EnvironmentVariablesSource();
        }
    }
}
