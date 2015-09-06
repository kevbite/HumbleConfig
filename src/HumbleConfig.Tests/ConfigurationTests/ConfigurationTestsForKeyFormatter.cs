using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.Tests.ConfigurationTests
{
    public class ConfigurationTestsForKeyFormatter<TValue> : AllValueTests<TValue>
    {
        private readonly Fixture _fixture = new Fixture();
        private string _formattedKey;
        private Mock<IConfigurationSource> _source;
        private Configuration _configuration;
        private string _key;

        [TestFixtureSetUp]
        public void GivenAnConfigurationWithACustomKeyFormatter()
        {
            _key = _fixture.Create<string>();
            _formattedKey = _fixture.Create<string>();
            var value = _fixture.Create<TValue>();
            var keyFormatter = new Mock<IKeyFormatter>();
            keyFormatter.Setup(x => x.FormatKey(_key))
                .Returns(_formattedKey);

            _source = new Mock<IConfigurationSource>();
            _source.Setup(x => x.TryGetAppSetting(_formattedKey, out value)).ReturnsAsync(true);
            
            _configuration = new Configuration();
            _configuration.AddConfigurationSource(_source.Object);
            _configuration.SetKeyFormatter(keyFormatter.Object);
        }

        [SetUp]
        public void WhenGettingAnAppSetting()
        {
            _configuration.GetAppSetting<TValue>(_key);
        }

        [Test]
        public void ThenTheSourceIsCalledWithTheFormattedKey()
        {
            TValue temp;
            _source.Verify(x => x.TryGetAppSetting(_formattedKey, out temp), Times.Once);
        }
    }
}
