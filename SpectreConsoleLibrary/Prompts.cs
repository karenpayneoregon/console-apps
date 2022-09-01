using System.Diagnostics.CodeAnalysis;
using EzPasswordValidator.Checks;
using EzPasswordValidator.Validators;
using Spectre.Console;
using static System.Globalization.DateTimeFormatInfo;

namespace SpectreConsoleLibrary;

public class Prompts
{
    public static string PromptStyleColor { get; set; } = "cyan";
    public static string GetFirstName(bool allowEmpty)
    {
        return allowEmpty
            ? AnsiConsole.Prompt(
                new TextPrompt<string>("[b]First name[/]")
                    .PromptStyle(PromptStyleColor)
                    .AllowEmpty())
            : AnsiConsole.Prompt(
                new TextPrompt<string>("[b]First name[/]:")
                    .PromptStyle(PromptStyleColor));
    }

    public static string GetLastName(bool allowEmpty)
    {
        if (allowEmpty)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>("[b]Last name[/]:")
                    .PromptStyle(PromptStyleColor)
                    .AllowEmpty());
        }
        else
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>("[b]Last name[/]:")
                    .PromptStyle(PromptStyleColor));
        }

    }
    public static int GetInt()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<int>("[b]Enter a number[/]:")
                .PromptStyle(PromptStyleColor)
                .ValidationErrorMessage("[red]That's not a number[/]"));
    }

    public static decimal GetDecimal()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<decimal>("[b]Enter decimal[/]")
                .PromptStyle(PromptStyleColor)
                .DefaultValue(1m));
    }

    public static int GetIntFrom1To10()
    {
        const int maxValue = 10;
        return AnsiConsole.Prompt(
            new TextPrompt<int>("[b]Enter a number[/] between [b]1[/] and [b]10[/]")
                .PromptStyle(PromptStyleColor)
                .ValidationErrorMessage("[red]That's not a valid entry[/]")
                .Validate(item => item switch
                {
                    <= 0 => ValidationResult.Error("[red]1 is min value[/]"),
                    >= maxValue => ValidationResult.Error($"[red]{maxValue} is max value[/]"),
                    _ => ValidationResult.Success(),
                }));
    }

    public static DateTime? GetBirthDate()
    {
        const int minYear = 1920;
        return AnsiConsole.Prompt(
            new TextPrompt<DateTime>("[b]Birth date[/]:")
                .PromptStyle(PromptStyleColor)
                .ValidationErrorMessage("[red]Please enter a valid date or press ENTER to not enter a date[/]")
                .Validate(dateTime => dateTime.Year switch
                {
                    <= minYear => ValidationResult.Error($"[red]Year must be greater than {minYear}[/]"),
                    _ => ValidationResult.Success(),
                })
                .AllowEmpty());
    }
    public static DateTime? GetDateTime()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<DateTime>("[b]Date[/]:")
                .PromptStyle(PromptStyleColor)
                .ValidationErrorMessage("[red]Please enter a valid date or press ENTER to not enter a date[/]")
                .AllowEmpty());
    }


    public static DateOnly? GetDate()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<DateOnly>("[b]Date[/]:")
                .PromptStyle(PromptStyleColor)
                .ValidationErrorMessage("[red]Please enter a valid date or press ENTER to not enter a date[/]")
                .AllowEmpty());
    }

    public static TimeOnly? GetTime()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<TimeOnly>("[b]Time[/]:")
                .PromptStyle(PromptStyleColor)
                .ValidationErrorMessage("[red]Please enter a valid time or press ENTER to not enter a time[/]")
                .AllowEmpty());
    }
    public static string GetUserName(bool allowEmpty)
    {
        return allowEmpty
            ? AnsiConsole.Prompt(
                new TextPrompt<string>("[b]First name[/]")
                    .PromptStyle(PromptStyleColor)
                    .AllowEmpty())
            : AnsiConsole.Prompt(
                new TextPrompt<string>("[b]First name[/]:")
                    .PromptStyle(PromptStyleColor));
    }

    public static string GetPassword() =>
        AnsiConsole.Prompt(
            new TextPrompt<string>("[b]Password[/]:")
                .PromptStyle("grey50")
                .Secret()
                .DefaultValueStyle(new Style(Color.Aqua)));

    public static string GetNewPassword() =>
        AnsiConsole.Prompt(
            new TextPrompt<string>("[b]First name[/]?")
                .PromptStyle(PromptStyleColor)
                .AllowEmpty()
                .Validate(ValidatePassword)
                .ValidationErrorMessage("[red]Entry does not match rules for creating a new password[/]"));

    private static ValidationResult ValidatePassword(string password)
    {
        PasswordValidator validator = new(CheckTypes.Symbols | CheckTypes.CaseUpperLower | CheckTypes.Numbers | CheckTypes.Length)
        {
            MinLength = 8
        };

        return validator.Validate(password) ? 
            ValidationResult.Success() : 
            ValidationResult.Error("Does not match rules for creating a password");
    }



    public static string AskUsernameIfMissing(string current)
        => !string.IsNullOrWhiteSpace(current)
            ? current
            : AnsiConsole.Prompt(
                new TextPrompt<string>("What's the username?")
                    .Validate(username
                        => !string.IsNullOrWhiteSpace(username)
                            ? ValidationResult.Success()
                            : ValidationResult.Error("[yellow]Invalid username[/]")));

    public static string AskPasswordIfMissing(string current)
        => TryGetValidPassword(current, out var validPassword)
            ? validPassword
            : AnsiConsole.Prompt(
                new TextPrompt<string>("What's the password?")
                    .Secret()
                    .Validate(password
                        => TryGetValidPassword(password, out _)
                            ? ValidationResult.Success()
                            : ValidationResult.Error("[yellow]Invalid password[/]")));

    public static bool TryGetValidPassword(string? password, [NotNullWhen(true)] out string? validPassword)
    {
        var isValidPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 2;
        validPassword = password;
        return isValidPassword;
    }

    public static List<string> QuestionOptions => new() { "Y", "N" };
    public static string Continue(string questionText, string color) =>
        AnsiConsole.Prompt(
            new TextPrompt<string>($"[{color}]{questionText}[/] {string.Join(",", QuestionOptions)}")
                .PromptStyle(PromptStyleColor)
                .DefaultValue("y")
                .ValidationErrorMessage($"[red]Valid responses[/] [white]{string.Join(",", QuestionOptions)}[/] [red]or press ENTER for default[/]")
                .Validate(text => QuestionOptions.Contains(text, StringComparer.CurrentCultureIgnoreCase) switch
                {
                    false => ValidationResult.Error("[red]Must be[/] [yellow]y[/] [red]or[/] [yellow]n[/]"),
                    _ => ValidationResult.Success()
                }));

    /// <summary>
    /// Ask for yes, no response
    /// </summary>
    /// <param name="questionText">question</param>
    /// <param name="color">foreground color</param>
    /// <returns>true or false</returns>
    /// <remarks>
    /// There is also AnsiConsole.Confirm but provides no option to
    /// change text color for (y/n)
    /// </remarks>
    public static bool AskConfirmation(string questionText, string color = "white")
    {
        return Continue(questionText, color).ToUpper() == "Y"; // AnsiConsole.Confirm("[lime]Perform another calculation?[/]");
    }

    public static List<string> MonthsSelection() => AnsiConsole.Prompt
    (
        new MultiSelectionPrompt<string>()
            .PageSize(12)
            .Required(false)
            .Title("[b]Months[/]?")
            .InstructionsText("[grey](Press [yellow]<space>[/] to toggle a month, [yellow]<enter>[/] to accept)[/] or [red]Enter[/] w/o any selections to cancel")
            .AddChoices(CurrentInfo!.MonthNames[..^1])
            .HighlightStyle(new Style(Color.White, Color.Black, Decoration.Invert))
    );
}