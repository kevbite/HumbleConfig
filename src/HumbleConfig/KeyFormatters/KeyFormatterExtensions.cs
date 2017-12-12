using HumbleConfig.InMemory;

namespace HumbleConfig.KeyFormatters
{
    public static class KeyFormatterExtensions
    {
        public static Configuration WithKeyPrefixer(this Configuration configuration, string prefix)
        {
            configuration.SetKeyFormatter(new KeyPrefixer(prefix));

            return configuration;
        }

        public static Configuration WithKeyPostfixer(this Configuration configuration, string postfix)
        {
            configuration.SetKeyFormatter(new KeyPostfixer(postfix));

            return configuration;
        }

        public static IConfigurationConfigurator WithKeyFormatter(this IConfigurationSourceConfigurator configuration, IKeyFormatter keyFormatter)
        {
            return configuration.WrapSource(x => new KeyFormatterConfigurationSourceDecorator(x, keyFormatter));
        }

        public static IConfigurationConfigurator WithKeyPrefixer(this IConfigurationSourceConfigurator configuration, string prefix)
        {
            return WithKeyFormatter(configuration, new KeyPrefixer(prefix));
        }

        public static IConfigurationConfigurator WithKeyPostfixer(this IConfigurationSourceConfigurator configuration, string postfix)
        {
            return WithKeyFormatter(configuration, new KeyPostfixer(postfix));
        }
    }
}
