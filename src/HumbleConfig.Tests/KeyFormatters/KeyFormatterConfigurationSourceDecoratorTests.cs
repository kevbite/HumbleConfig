using System.Threading;
using System.Threading.Tasks;
using HumbleConfig.KeyFormatters;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace HumbleConfig.Tests.KeyFormatters
{
    [TestFixture]
    public class KeyFormatterConfigurationSourceDecoratorTests
    {
        private KeyFormatterConfigurationSourceDecorator _decorator;
        private Mock<IKeyFormatter> _keyFormatter;
        private Mock<IConfigurationSource> _configurationSource;
        private Fixture _fixture;

        [OneTimeSetUp]
        public void GivenAKeyFormatterConfigurationSourceDecorator()
        {
            _fixture = new Fixture();
            _keyFormatter = new Mock<IKeyFormatter>();
            _configurationSource = new Mock<IConfigurationSource>();
            _decorator = new KeyFormatterConfigurationSourceDecorator(_configurationSource.Object, _keyFormatter.Object);
        }

        [Test]
        public async Task WhenGettingValue_ThenConfigurationSourceIsCalledWithNewKeyAndCorrectValueReturned()
        {
            var key = _fixture.Create("key");
            var newKey = _fixture.Create("newKey");
            _keyFormatter.Setup(x => x.FormatKey(key))
                .Returns(newKey);

            var cancellationToken = new CancellationToken();
            var value = _fixture.Create("value");
            _configurationSource.Setup(x => x.GetAppSettingAsync<string>(newKey, cancellationToken))
                .ReturnsAsync(ConfigurationSourceResult<string>.SuccessResult(value));

            var actual = await _decorator.GetAppSettingAsync<string>(key, cancellationToken);

            Assert.IsTrue(actual.KeyExists);
            Assert.AreEqual(value, actual.Value);
        }
    }
}
