# HumbleConfig

*Stop writing boiler plate configuration code to pull from different sources.*

HumbleConfig allows developers to concentrate on writing the application instead of managing all the configuration locations.

[![install from nuget](http://img.shields.io/nuget/v/HumbleConfig.svg?style=flat-square)](https://www.nuget.org/packages/HumbleConfig)[![downloads](http://img.shields.io/nuget/dt/HumbleConfig.svg?style=flat-square)](https://www.nuget.org/packages/HumbleConfig)

### How to use it?
First, create an `Configuration` instance:
```csharp
var configuration = new Configuration();
```
Then, configure the sources for configuration:
```csharp
configuration.AddEnvironmentVariables()
             .AddConfigurationManager();
```
Once we're happy we can pull out an app setting:
```csharp
var value = configuration.GetAppSetting("key");
```