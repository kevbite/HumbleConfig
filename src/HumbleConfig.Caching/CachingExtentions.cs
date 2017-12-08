namespace HumbleConfig.Caching
{
    public static class CachingExtentions
    {
        public static IConfigurationSourceConfigurator WithCaching(this IConfigurationSourceConfigurator a)
        {
            return a.WrapSource(x => x);
        }
    }
}