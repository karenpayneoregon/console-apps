# About

In this example we ask for a count that will then loop through a `while` statement asking for an `int`.

The method `GetNumber` is no different than other example other than it accepts text to display and a default value.

```csharp
/// <summary>
/// Prompt for int
/// </summary>
/// <param name="prompt">Text to display</param>
/// <param name="defaultValue">Default value is used if enter if pressed</param>
/// <returns>int</returns>
/// <remarks>
/// Advance use can have validation, omitted here
/// </remarks>
internal static int GetNumber(string prompt, int defaultValue)
{
    return AnsiConsole.Prompt(
        new TextPrompt<int>($"[white]{prompt}[/]")
            .PromptStyle("white")
            .DefaultValueStyle(new Style(Color.Yellow))
            .DefaultValue(defaultValue)
            .ValidationErrorMessage("[white on red]Invalid entry![/]"));
}
```

# Note

Written after reading a Stackoverflow [post](https://stackoverflow.com/questions/74186928/int-tryparse-when-inout-is-a-string-will-still-fill-up-an-array-slot#74186988), did not respond as they are a novice coder.

Well shortly after writing this the person asking the question deleted the post.