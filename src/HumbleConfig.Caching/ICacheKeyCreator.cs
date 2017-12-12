namespace HumbleConfig.Caching
{
    public interface ICacheKeyCreator
    {
        string CreateCacheKey(string key);
    }
}