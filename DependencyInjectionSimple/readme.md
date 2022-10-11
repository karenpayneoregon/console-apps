# How to implement dependency injection in a console project.

Simple example for `dependency injection` for EF Core and simple logging in a console project. 

> **Note**
>The Dependency Injection Design Pattern in C# allows us to develop loosely coupled software components. In other words, we can say that Dependency Injection Design Pattern is used to reduce the tight coupling between the software components. As a result, we can easily manage future changes and other complexity in our application.



# Why in a console project?

If for no other reason, consider this for learning which can be taken forward into ASP.NET Core. Otherwise there is really no reason to use DI for smaller projects but that is up to each developer.

# Data script

For the data access sample, run script.sql under the scripts folder first.

# NuGet packages

:beginner: Recommend not copy and pasting from the project file as time goes by there most likely will be newer versions of each package

- `Microsoft.EntityFrameworkCore.SqlServer` for EF Core
- Microsoft.Extensions.Configuration
    - `Microsoft.Extensions.Configuration.EnvironmentVariables`
    - `Microsoft.Extensions.Configuration.FileExtensions`
    - `Microsoft.Extensions.Configuration.Json`
- `Microsoft.Extensions.DependencyInjection`
    - `Microsoft.Extensions.DependencyInjection.Abstractions`
- `Microsoft.Extensions.Logging`
    - `Microsoft.Extensions.Logging.Console`
    - `Microsoft.Extensions.Logging.Debug`
    - `Microsoft.Extensions.Options`
- `ConfigurationLibrary` for reading connection strings from `appsettings.json`
- `ConsoleHelperLibrary` provides methods to position console windows
- `Spectre.Console`  library that makes it easier to create beautiful console applications. (there are many code samples in this repository)

![Screen](assets/screen.png)

## appsettings.json

Stored information for both classes

1.  <kbd>App</kbd> is for `App.cs` which reads `TempDirectory` and appends to Path.Combine. Note `Temp` is created under bin folder via a MS Build after build command in the project file.
1. ConnectionsConfiguration is read in via my NuGet package [ConfigurationLibrary](https://www.nuget.org/packages/ConfigurationLibrary/).
1. `Logging.Microsoft.EntityFrameworkCore` turns off logging for EF Core for work done in <kbd>DataAccess</kbd>

```json
{
  "App": {
    "TempDirectory": "Temp"
  },
  "ConnectionsConfiguration": {
    "ActiveEnvironment": "Development",
    "Development": "Server=(localdb)\\MSSQLLocalDB;Database=OED.Pizza;Trusted_Connection=True",
    "Stage": "Stage connection string goes here",
    "Production": "Prod connection string goes here"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Information",
      "Microsoft.Hosting.Lifetime": "Information",
      "Microsoft.EntityFrameworkCore": "None"
    }
  }
}
```

# After build command

Used to ensure the path exists under the executable folder for <kbd>App.Run()</kbd> class.

```xml
<Target Name="MakeTempFolder" AfterTargets="Build">
	<MakeDir Directories="$(OutDir)Temp" />
</Target>
```