namespace HumbleConfig.KeyFormatters
{
    public class KeyPrefixer : IKeyFormatter
    {
        private readonly string _keyPrefix;

        public KeyPrefixer(string keyPrefix)
        {
            _keyPrefix = keyPrefix;
        }

        public string FormatKey(string key)
        {
            return string.Format($"{_keyPrefix}{key}");
        }
    }
}