namespace HumbleConfig.KeyFormatters
{
    public class KeyPostfixer : IKeyFormatter
    {
        private readonly string _keyPostfix;

        public KeyPostfixer(string keyPostfix)
        {
            _keyPostfix = keyPostfix;
        }

        public string FormatKey(string key)
        {
            return string.Format($"{key}{_keyPostfix}");
        }
    }
}