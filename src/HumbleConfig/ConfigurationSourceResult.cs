namespace HumbleConfig
{
    public class ConfigurationSourceResult<TValue>
    {
        private ConfigurationSourceResult()
        {
        }

        public static ConfigurationSourceResult<TValue> SuccessResult(TValue value)
        {
            return new ConfigurationSourceResult<TValue>()
            {
                KeyExists = true,
                Value = value
            };
        }

        public static ConfigurationSourceResult<TValue> FailedResult()
        {
            return new ConfigurationSourceResult<TValue>()
            {
                KeyExists = false,
                Value = default(TValue)
            };
        }

        public bool KeyExists { get; private set; }

        public TValue Value { get; private set; }
    }
}