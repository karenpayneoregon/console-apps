# About

The package CommandLineParser provides an option for a default verb as described [here](https://github.com/commandlineparser/commandline/wiki/Verbs) but there are full fledge code samples so I took the parts given and created this project.

Run with the following is how we normally pass a verb

```
say --hello Karen
```

But with

```csharp
[Verb("say", true, HelpText = "say hello")]
public class DefaultVerbOption
{
    [Option('f', "hello", Required = true)]
    public string FirstName { get; set; }
}
```

We can bypass `say`


```
--hello Karen
```

