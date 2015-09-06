using HumbleConfig.Tests;
using MongoDB.Bson;
using MongoDB.Driver;

namespace HumbleConfig.MongoDb.Tests.MongoDbSourceTests
{
    public class MongoDbSourceFactory : IConfigurationSourceFactory
    {
        public IConfigurationSource Create()
        {
            var collection = new MongoClient().GetDatabase("test").GetCollection<MongoDbSource.AppSetting>("appSettings");

            return new MongoDbSource(collection);
        }

        public IConfigurationSource Create<TValue>(string key, TValue value)
        {
            var collection = new MongoClient().GetDatabase("test").GetCollection<MongoDbSource.AppSetting>("appSettings");
            
            collection.InsertOneAsync(new MongoDbSource.AppSetting()
            {
                 Id = key,
                 Value = value
            }).Wait();

            return new MongoDbSource(collection);
        }
    }
}