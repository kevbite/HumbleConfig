# HumbleConfig

*Stop writing boiler plate configuration code to pull from different sources.*

HumbleConfig allows developers to concentrate on writing the application instead of managing all the configuration locations.

[![install from nuget](http://img.shields.io/nuget/v/HumbleConfig.svg?style=flat-square)](https://www.nuget.org/packages/HumbleConfig)[![downloads](http://img.shields.io/nuget/dt/HumbleConfig.svg?style=flat-square)](https://www.nuget.org/packages/HumbleConfig)
[![Build status](https://ci.appveyor.com/api/projects/status/bodd6hrcoltpco6i/branch/master?svg=true)](https://ci.appveyor.com/project/kevbite/humbleconfig/branch/master)

### Installing packages

```powershell
PM> Install-Package HumbleConfig
```
```powershell
PM> Install-Package HumbleConfig.ConfigurationManager
```
```powershell
PM> Install-Package HumbleConfig.EnvironmentVariables
```
```powershell
PM> Install-Package HumbleConfig.ConfigR
```

### How to use it?
First, create an `Configuration` instance:
```csharp
var configuration = new Configuration();
```
Then, configure the sources for configuration:
```csharp
configuration.AddEnvironmentVariables()
             .AddConfigurationManager()
			 .AddConfigR();
```
We can also add some default values by using a InMemory source:
```csharp
var defaults = new Dictionary<string, string>() { {"UserName", "Kevin.Smith"} };

configuration.AddInMemory(defaults);
```
Once we're happy with our configuration we can pull out an app setting:
```csharp
var value = configuration.GetAppSetting("key");
```
### Key formatters
Ever been in config hell where you don't know what key is used where.
This is where key formatters comes in useful, HumbleConfig has inbuilt support for a few key formatters.

#### KeyPrefixer
The key prefixer allows you to specify a prefix that all your config keys should include.
For example having a prefix of `HumbleConfig:` would have the following output:

| Key    | Source Key        |
| -------|------------------ |
| Key1   | HumbleConfig:Key1 |
| Key2   | HumbleConfig:Key2 |
| Key3   | HumbleConfig:Key3 |

To setup this the key prefixer on our configuration object we just call `WithKeyPrefixer`:
```csharp
configuration.WithKeyPrefixer("HumbleConfig:")
```

### Contributing

 1. Fork
 1. Hack!
 1. Pull Request.

###
