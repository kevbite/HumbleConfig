namespace HumbleConfig.KeyFormatters
{
    public static class KeyFormatterExtensions
    {
        public static Configuration WithKeyPrefixer(this Configuration configuration, string prefix)
        {
            configuration.SetKeyFormatter(new KeyPrefixer(prefix));

            return configuration;
        }
    }
}
