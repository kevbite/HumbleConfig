using HumbleConfig.Tests;
using MongoDB.Driver;

namespace HumbleConfig.MongoDb.Tests.MongoDbSourceTests
{
    public class MongoDbSourceTestsForExistingKey<TValue> : ConfigurationSourceTestsForExistingKey<TValue>
    {
        protected override IConfigurationSource GivenConfigurationSourceWithExistingRKey(string key, TValue value)
        {
            var collection = new MongoClient().GetDatabase("test").GetCollection<AppSetting>("appSettings");

            collection.InsertOneAsync(new AppSetting()
            {
                Id = key,
                Value = value
            }).Wait();

            return new MongoDbSource(collection);
        }
    }
}
