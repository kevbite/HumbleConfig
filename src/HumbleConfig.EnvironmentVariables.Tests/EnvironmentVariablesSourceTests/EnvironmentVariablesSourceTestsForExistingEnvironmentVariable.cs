using System.Net.Http.Headers;
using HumbleConfig.Tests;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.EnvironmentVariables.Tests.EnvironmentVariablesSourceTests
{
    public class EnvironmentVariablesSourceTestsForExistingEnvironmentVariable<TValue> : ConfigurationSourceTestsForExistingKey<TValue, EnvironmentVariablesSourceFactory>
    {
    }
}
