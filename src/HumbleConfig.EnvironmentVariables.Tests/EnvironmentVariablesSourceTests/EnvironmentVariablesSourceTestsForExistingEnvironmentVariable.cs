using System;
using System.Net.Http.Headers;
using HumbleConfig.Tests;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.EnvironmentVariables.Tests.EnvironmentVariablesSourceTests
{
    public class EnvironmentVariablesSourceTestsForExistingEnvironmentVariable<TValue> : ConfigurationSourceTestsForExistingKey<TValue, EnvironmentVariablesSourceFactory>
    {
    }

    public class EnvironmentVariablesSourceFactory : IConfigurationSourceFactory
    {
        public IConfigurationSource Create<TValue>(string key, TValue value)
        {
            Environment.SetEnvironmentVariable(key, value.ToString());

            return new EnvironmentVariablesSource();
        }
    }
}
