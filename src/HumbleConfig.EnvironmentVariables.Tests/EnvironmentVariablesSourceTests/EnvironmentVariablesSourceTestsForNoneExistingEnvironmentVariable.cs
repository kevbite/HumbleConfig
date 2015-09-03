using System;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.EnvironmentVariables.Tests.EnvironmentVariablesSourceTests
{
    [TestFixture]
    public class EnvironmentVariablesSourceTestsForNoneExistingEnvironmentVariable
    {
        private string _value;
        private bool _result;
        private string _variableName;

        [TestFixtureSetUp]
        public void GivenAnEnvironmentVariableDoesNotExist()
        {
            var fixture = new Fixture();
            _variableName = fixture.Create<string>();

            Environment.SetEnvironmentVariable(_variableName, null);
        }

        [SetUp]
        public void WhenGettingAppSettings()
        {
            var source = new EnvironmentVariablesSource();

            _result = source.TryGetAppSetting(_variableName, out _value);
        }

        [Test]
        public void ThenTheResultIsFalse()
        {
            Assert.That(_result, Is.False);
        }

        [Test]
        public void ThenTheValueIsNull()
        {
            Assert.That(_value, Is.Null);
        }
    }
}
