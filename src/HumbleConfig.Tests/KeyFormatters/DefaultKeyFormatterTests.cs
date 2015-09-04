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
    public class DefaultKeyFormatterTests
    {
        private DefaultKeyFormatter _formatter;
        private string _key;
        private string _formattedKey;

        [TestFixtureSetUp]
        public void GivenADefaultKeyFormatter()
        {
            _formatter = new DefaultKeyFormatter();
        }

        [SetUp]
        public void WhenFormattingTheKey()
        {
            _key = new Fixture().Create<string>();
            _formattedKey = _formatter.FormatKey(_key);
        }

        [Test]
        public void ThenTheSameKeyIsReturned()
        {
            Assert.That(_formattedKey, Is.EqualTo(_key));
        }
    }
}
