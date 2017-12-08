using Amazon.DynamoDBv2;
using Amazon.Internal;
using Amazon.KeyManagementService;
using Narochno.Credstash;

namespace HumbleConfig.Credstash
{
    public static class CredstashExtensions
    {
        public static Configuration AddCredstash(this Configuration configuration, CredstashOptions options, IAmazonKeyManagementService amazonKeyManagementService, IAmazonDynamoDB amazonDynamoDb)
        {
            var credstash = new Narochno.Credstash.Credstash(options, amazonKeyManagementService, amazonDynamoDb);

            configuration.AddConfigurationSource(new CredstashSource(credstash));

            return configuration;
        }

        public static Configuration AddCredstash(this Configuration configuration, Amazon.RegionEndpoint region, string table)
        {
            var credstashOptions = new CredstashOptions()
            {
                Region = region,
                Table = table
            };

            var amazonKeyManagementServiceClient = new AmazonKeyManagementServiceClient(region);
            var amazonDynamoDbClient = new AmazonDynamoDBClient(region);

            return AddCredstash(configuration, credstashOptions, amazonKeyManagementServiceClient, amazonDynamoDbClient);
        }
    }
}
