using System.Runtime.InteropServices;
using MongoDB.Driver;

namespace HumbleConfig.MongoDb
{
    public static class MongoDbExtensions
    {
        public static Configuration AddMongoDb(this Configuration configuration, MongoUrl mongoUrl, string collectionName)
        {
            var mongoClient = new MongoClient(mongoUrl);
            var database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
            var collection = database.GetCollection<AppSetting>(collectionName);

            configuration.AddConfigurationSource(new MongoDbSource(collection));

            return configuration;
        }
        public static Configuration AddMongoDb(this Configuration configuration, string url, string collectionName)
        {
            var mongoUrl = new MongoUrl(url);

            return configuration.AddMongoDb(mongoUrl, collectionName);
        }
    }
}