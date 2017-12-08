using Amazon.DynamoDBv2;
using Amazon.Internal;
using Amazon.KeyManagementService;
using Narochno.Credstash;

namespace HumbleConfig.Credstash
{
    public static class CredstashExtensions
    {
        public static IConfigurationSourceConfigurator AddCredstash(this IConfigurationConfigurator configuration, CredstashOptions options, IAmazonKeyManagementService amazonKeyManagementService, IAmazonDynamoDB amazonDynamoDb)
        {
            var credstash = new Narochno.Credstash.Credstash(options, amazonKeyManagementService, amazonDynamoDb);

            return configuration.AddConfigurationSource(new CredstashSource(credstash));

            
        }

        public static IConfigurationSourceConfigurator AddCredstash(this IConfigurationConfigurator configuration, Amazon.RegionEndpoint region, string table)
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
