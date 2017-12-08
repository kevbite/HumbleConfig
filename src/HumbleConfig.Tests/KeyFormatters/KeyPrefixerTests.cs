using HumbleConfig.KeyFormatters;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.Tests.KeyFormatters
{
    public class KeyPrefixerTests
    {
        private KeyPrefixer _formatter;
        private string _key;
        private string _formattedKey;
        private string _prefix;

        [OneTimeSetUp]
        public void GivenAKeyPrefixer()
        {
            _prefix = new Fixture().Create<string>();
            _formatter = new KeyPrefixer(_prefix);
        }

        [SetUp]
        public void WhenFormattingTheKey()
        {
            _key = new Fixture().Create<string>();
            _formattedKey = _formatter.FormatKey(_key);
        }

        [Test]
        public void ThenTheKeyIsPrefixed()
        {
            Assert.That(_formattedKey, Does.StartWith(_prefix));
        }

        [Test]
        public void ThenTheFormattedKeyEndWithTheKey()
        {
            Assert.That(_formattedKey, Does.EndWith(_key));
        }

        [Test]
        public void ThenTheFormattedKeyIsTheCorrectLength()
        {
            var expectedLength = _key.Length + _prefix.Length;

            Assert.That(_formattedKey.Length, Is.EqualTo(expectedLength));
        }
    }
}
