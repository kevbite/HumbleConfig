using System;
using HumbleConfig.Tests;

namespace HumbleConfig.EnvironmentVariables.Tests.EnvironmentVariablesSourceTests
{
    public class EnvironmentVariablesSourceFactory : IConfigurationSourceFactory
    {
        public IConfigurationSource Create()
        {
            return new EnvironmentVariablesSource();
        }

        public IConfigurationSource Create<TValue>(string key, TValue value)
        {
            Environment.SetEnvironmentVariable(key, value.ToString());

            return Create();
        }
    }
}