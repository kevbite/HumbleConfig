using System.Net.Http.Headers;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace HumbleConfig.MongoDb
{
    public class MongoDbSource : IConfigurationSource
    {
        private readonly IMongoCollection<AppSetting> _collection;

        public MongoDbSource(IMongoCollection<AppSetting> collection)
        {
            _collection = collection;
        }

        public async Task<ConfigurationSourceResult<TValue>> TryGetAppSetting<TValue>(string key)
        {
            var document = await _collection.Find(new BsonDocument("_id", key))
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            if (document == null)
            {
                return ConfigurationSourceResult<TValue>.FailedResult();
            }
            
            return
                ConfigurationSourceResult<TValue>.SuccessResult(
                    (TValue) document.Value);
        }
    }
}