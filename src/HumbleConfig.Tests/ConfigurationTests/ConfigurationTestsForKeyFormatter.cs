using System.Threading;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.Tests.ConfigurationTests
{
    [TestFixtureSource(typeof(NonNullableTestFixtureCases))]
    [TestFixtureSource(typeof(NullableTestFixtureCases))]
    public class ConfigurationTestsForKeyFormatter<TValue>
    {
        private readonly Fixture _fixture = new Fixture();
        private string _formattedKey;
        private Mock<IConfigurationSource> _source;
        private Configuration _configuration;
        private string _key;

        [OneTimeSetUp]
        public void GivenAnConfigurationWithACustomKeyFormatter()
        {
            _key = _fixture.Create<string>();
            _formattedKey = _fixture.Create<string>();
            var value = _fixture.Create<TValue>();
            var keyFormatter = new Mock<IKeyFormatter>();
            keyFormatter.Setup(x => x.FormatKey(_key))
                .Returns(_formattedKey);

            _source = new Mock<IConfigurationSource>();
            _source.Setup(x => x.GetAppSettingAsync<TValue>(_formattedKey, default(CancellationToken)))
                            .ReturnsAsync(ConfigurationSourceResult<TValue>.SuccessResult(value));
            
            _configuration = new Configuration();
            _configuration.AddConfigurationSource(_source.Object);
            _configuration.SetKeyFormatter(keyFormatter.Object);
        }

        [SetUp]
        public void WhenGettingAnAppSetting()
        {
            _configuration.GetAppSettingAsync<TValue>(_key).Wait();
        }

        [Test]
        public void ThenTheSourceIsCalledWithTheFormattedKey()
        {
            _source.Verify(x => x.GetAppSettingAsync<TValue>(_formattedKey, default(CancellationToken)), Times.Once);
        }
    }
}
