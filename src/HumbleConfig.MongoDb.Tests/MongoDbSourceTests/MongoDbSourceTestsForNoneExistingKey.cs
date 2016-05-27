using HumbleConfig.Tests;
using MongoDB.Driver;
using NUnit.Framework;

namespace HumbleConfig.MongoDb.Tests.MongoDbSourceTests
{
    [TestFixtureSource(typeof(NonNullableTestFixtureCases))]
    [TestFixtureSource(typeof(NullableTestFixtureCases))]
    public class MongoDbSourceTestsForNoneExistingKey<TValue> : ConfigurationSourceTestsForNoneExistingKey<TValue>
    {
        protected override IConfigurationSource CreateConfigurationSource()
        {
            var collection = new MongoClient().GetDatabase("test").GetCollection<AppSetting>("appSettings");
            
            return new MongoDbSource(collection);
        }
    }
}
