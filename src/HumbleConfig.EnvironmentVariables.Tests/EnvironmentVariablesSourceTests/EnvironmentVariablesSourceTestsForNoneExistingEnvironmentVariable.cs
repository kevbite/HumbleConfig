using System;
using HumbleConfig.Tests;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.EnvironmentVariables.Tests.EnvironmentVariablesSourceTests
{
    [TestFixture]
    public class EnvironmentVariablesSourceTestsForNoneExistingEnvironmentVariable<TValue> : ConfigurationSourceTestsForNoneExistingKey<TValue, EnvironmentVariablesSourceFactory>
    {

    }
}
