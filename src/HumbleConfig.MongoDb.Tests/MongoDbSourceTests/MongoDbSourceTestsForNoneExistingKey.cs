using HumbleConfig.Tests;
using MongoDB.Driver;

namespace HumbleConfig.MongoDb.Tests.MongoDbSourceTests
{
    public class MongoDbSourceTestsForNoneExistingKey<TValue> : ConfigurationSourceTestsForNoneExistingKey<TValue>
    {
        protected override IConfigurationSource CreateConfigurationSource()
        {
            var collection = new MongoClient().GetDatabase("test").GetCollection<AppSetting>("appSettings");
            
            return new MongoDbSource(collection);
        }
    }
}
