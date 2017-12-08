using System;

namespace HumbleConfig
{
    public interface IConfigurationSourceConfigurator : IConfigurationConfigurator
    {
        IConfigurationSourceConfigurator WrapSource(Func<IConfigurationSource, IConfigurationSource> func);
    }
}