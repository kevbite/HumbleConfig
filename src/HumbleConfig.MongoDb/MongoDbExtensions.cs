using MongoDB.Driver;

namespace HumbleConfig.MongoDb
{
    public static class MongoDbExtensions
    {
        public static IConfigurationSourceConfigurator AddMongoDb(this IConfigurationConfigurator configuration, MongoUrl mongoUrl, string collectionName)
        {
            var mongoClient = new MongoClient(mongoUrl);
            var database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
            var collection = database.GetCollection<AppSetting>(collectionName);

            return configuration.AddConfigurationSource(new MongoDbSource(collection));
        }

        public static IConfigurationSourceConfigurator AddMongoDb(this IConfigurationConfigurator configuration, string url, string collectionName)
        {
            var mongoUrl = new MongoUrl(url);

            return configuration.AddMongoDb(mongoUrl, collectionName);
        }
    }
}