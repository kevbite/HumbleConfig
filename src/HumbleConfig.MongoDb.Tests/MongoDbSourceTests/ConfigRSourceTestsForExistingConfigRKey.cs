using HumbleConfig.Tests;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HumbleConfig.MongoDb.Tests.MongoDbSourceTests
{
    public class MongoDbSourceTestsForExistingKey<TValue> : ConfigurationSourceTestsForExistingKey<TValue>
    {
        private readonly IMongoCollection<AppSetting> _collection = new MongoClient().GetDatabase("test").GetCollection<AppSetting>("appSettings");

        protected override IConfigurationSource GivenConfigurationSourceWithExistingRKey(string key, TValue value)
        {
            _collection.InsertOneAsync(new AppSetting()
            {
                Id = key,
                Value = value
            }).Wait();

            return new MongoDbSource(_collection);
        }

        protected override void DestroyEvidence(string key)
        {
            _collection.DeleteOneAsync(new BsonDocument("_id", key)).Wait();
        }
    }
}
