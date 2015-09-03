using System;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.EnvironmentVariables.Tests.EnvironmentVariablesSourceTests
{
    [TestFixture]
    public class EnvironmentVariablesSourceTestsForExistingEnvironmentVariable
    {
        private string _value;
        private bool _result;
        private string _variableName;
        private string _expectedValue;

        [TestFixtureSetUp]
        public void GivenAnExistingEnvironmentVariable()
        {
            var fixture = new Fixture();
            _variableName = fixture.Create<string>();
            _expectedValue = fixture.Create<string>();

            Environment.SetEnvironmentVariable(_variableName, _expectedValue);
        }

        [SetUp]
        public void WhenGettingAppSettings()
        {
            var source = new EnvironmentVariablesSource();

            _result = source.TryGetAppSetting(_variableName, out _value);
        }

        [Test]
        public void ThenTheResultIsTrue()
        {
            Assert.That(_result, Is.True);
        }

        [Test]
        public void ThenTheValueIsAsExpected()
        {
            Assert.That(_value, Is.EqualTo(_expectedValue));
        }
    }
}
