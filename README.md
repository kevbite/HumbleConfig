# HumbleConfig

*Stop writing boiler plate configuration code to pull from different sources.*

HumbleConfig allows developers to concentrate on writing the application instead of managing all the configuration locations.

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