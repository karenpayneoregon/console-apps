# About

Simple example for asking user for a string input with various options along with special validations.


```csharp
namespace GetStringApp.Classes;

public class Prompts
{
    public static string PromptStyleColor { get; set; } = "cyan";
    public static string PromptColor { get; set; } = "b";

    /// <summary>
    /// Ask for a string, optionally allow an empty value
    /// </summary>
    /// <param name="allowEmpty">true to allow empty e.g. pressing enter to abort while
    /// using false user must enter a value</param>
    /// <param name="title">What to present to a user e.g. Enter first name</param>
    /// <returns>string value or empty string</returns>
    public static string GetString(bool allowEmpty, string title = "Enter a value")
    {
        return allowEmpty
            ? AnsiConsole.Prompt(
                new TextPrompt<string>($"[{PromptColor}]{title}[/]")
                    .PromptStyle(PromptStyleColor)
                    .AllowEmpty())
            : AnsiConsole.Prompt(
                new TextPrompt<string>($"[{PromptColor}]{title}[/]:")
                    .PromptStyle(PromptStyleColor));
    }

    /// <summary>
    /// Example for asking for a first name.
    /// Rule is, string must have at least three character, if less they
    /// are prompted to continue or abort.
    /// </summary>
    /// <returns></returns>
    public static string GetFirstName() =>
        AnsiConsole.Prompt(
            new TextPrompt<string>($"[{PromptColor}]First name[/]?")
                .PromptStyle(PromptStyleColor)
                .AllowEmpty()
                .Validate(value => value.Trim().Length switch
                {
                    < 3 => ValidateFirstName(),
                    _ => ValidationResult.Success(),
                })
                .ValidationErrorMessage("[red]Please enter your first name[/]"));

    /// <summary>
    /// Here when validation fails for <see cref="GetFirstName"/> they are asked to continue,
    /// if they want to continue they are ask for a value again else exit the app.
    /// </summary>
    /// <remarks>
    /// The decision to continue here is exit the app but can be whatever you want.
    /// </remarks>
    private static ValidationResult ValidateFirstName()
    {

        if (!Prompt.GetYesNo("Do you want to continue?", true, ConsoleColor.Cyan))
        {
            Environment.Exit(0);
        }

        return ValidationResult.Error("[red]Must have at least three characters[/]");

    }
}
```