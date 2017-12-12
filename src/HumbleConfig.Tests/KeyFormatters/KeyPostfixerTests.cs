using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HumbleConfig.KeyFormatters;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.Tests.KeyFormatters
{
    [TestFixture]
    public class KeyPostfixerTests
    {
        private KeyPostfixer _formatter;
        private string _key;
        private string _formattedKey;
        private string _postfix;

        [OneTimeSetUp]
        public void GivenAKeyPrefixer()
        {
            _postfix = new Fixture().Create<string>();
            _formatter = new KeyPostfixer(_postfix);
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
            Assert.That(_formattedKey, Does.EndWith(_postfix));
        }

        [Test]
        public void ThenTheFormattedKeyEndWithTheKey()
        {
            Assert.That(_formattedKey, Does.StartWith(_key));
        }

        [Test]
        public void ThenTheFormattedKeyIsTheCorrectLength()
        {
            var expectedLength = _key.Length + _postfix.Length;

            Assert.That(_formattedKey.Length, Is.EqualTo(expectedLength));
        }
    }
}
