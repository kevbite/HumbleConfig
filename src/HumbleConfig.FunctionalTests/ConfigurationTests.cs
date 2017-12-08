using System;
using System.Collections.Generic;
using System.Reflection;
using ConfigR;
using HumbleConfig.ConfigR;
using HumbleConfig.ConfigurationManager;
using HumbleConfig.EnvironmentVariables;
using HumbleConfig.InMemory;
using HumbleConfig.MongoDb;
using MongoDB.Bson;
using MongoDB.Driver;
using NUnit.Framework;

namespace HumbleConfig.FunctionalTests
{
    [TestFixture]
    public class ConfigurationTests
    {
        private IConfiguration _configuration;

        private string key1 = "key1";
        private string key2 = "key2";
        private string key3 = "key3";
        private string key4 = "key4";
        private string key5 = "key5";
        private string key6 = "key6";
        private string key7 = "key7";

        private string _key1Actual;
        private string _key2Actual;
        private string _key3Actual;
        private string _key4Actual;
        private string _key5Actual;
        private string _key6Actual;
        private string _key7Actual;

        private readonly IMongoCollection<AppSetting> _mongoCollection = new MongoClient().GetDatabase(Guid.NewGuid().ToString())
                .GetCollection<AppSetting>("appSettings");

        [OneTimeSetUp]
        public void GivenConfigurationWithEnvironmentVaribleAndConfigurationManager()
        {
            Environment.SetEnvironmentVariable(key1, "EnvironmentVariable");
            Environment.SetEnvironmentVariable(key2, "EnvironmentVariable");
            
            _mongoCollection
                .InsertOneAsync(new AppSetting() {Id = key7, Value = "MongoDB"})
                .Wait();

            _configuration = new Configuration()
                .AddEnvironmentVariables()
                .AddConfigurationManager()
                .AddInMemory(new Dictionary<string, object>() { {key5, "InMemory"} })
                .AddConfigR(Config.Global.LoadScriptFile(new Uri(Assembly.GetExecutingAssembly().CodeBase + ".csx").LocalPath))
                .AddMongoDb($"mongodb://localhost/{_mongoCollection.Database.DatabaseNamespace}", "appSettings")
                .GetConfiguration();
        }

        [SetUp]
        public void WhenGettingAppSettings()
        {
            _key1Actual = _configuration.GetAppSettingAsync<string>(key1).Result;
            _key2Actual = _configuration.GetAppSettingAsync<string>(key2).Result;
            _key3Actual = _configuration.GetAppSettingAsync<string>(key3).Result;
            _key4Actual = _configuration.GetAppSettingAsync<string>(key4).Result;
            _key5Actual = _configuration.GetAppSettingAsync<string>(key5).Result;
            _key6Actual = _configuration.GetAppSettingAsync<string>(key6).Result;
            _key7Actual = _configuration.GetAppSettingAsync<string>(key7).Result;
        }

        [Test]
        public void ThenKey1PullsValueFromEnvironmentVariable()
        {
            Assert.That(_key1Actual, Is.EqualTo("EnvironmentVariable"));
        }

        [Test]
        public void ThenKey2PullsValueFromEnvironmentVariable()
        {
            Assert.That(_key2Actual, Is.EqualTo("EnvironmentVariable"));
        }

        [Test]
        public void ThenKey3PullsValueFromAppConfig()
        {
            Assert.That(_key3Actual, Is.EqualTo("App.Config"));
        }

        [Test]
        public void ThenKey4IsNull()
        {
            Assert.That(_key4Actual, Is.Null);
        }

        [Test]
        public void ThenKey5PullsFromInMemory()
        {
            Assert.That(_key5Actual, Is.EqualTo("InMemory"));
        }

        [Test]
        public void ThenKey6PullsFromConfigR()
        {
            Assert.That(_key6Actual, Is.EqualTo("ConfigR"));
        }

        [Test]
        public void ThenKey7PullsFromMongoDb()
        {
            Assert.That(_key7Actual, Is.EqualTo("MongoDB"));
        }

        [OneTimeTearDown]
        public void DestroyEvidence()
        {
            _mongoCollection.DeleteOneAsync(new BsonDocument("_id", key7)).Wait();
        }
    }
}
