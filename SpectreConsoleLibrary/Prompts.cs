#nullable disable
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

    public static double GetDouble()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<double>("[b]Enter decimal[/]")
                .PromptStyle(PromptStyleColor)
                .DefaultValue(1));
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


    public static DateOnly? GetDateOnly(string defaultValue = "09/01/2022")
    {
        var input =AnsiConsole.Prompt(
            new TextPrompt<string>("[b]Date[/]:")
                .PromptStyle(PromptStyleColor)
                .DefaultValue(defaultValue)
                .ValidationErrorMessage("[red]Please enter a valid date or press ENTER to not enter a date[/]")
                .AllowEmpty());

        if (DateOnly.TryParse(input, out var date))
        {
            return date;
        }
        else
        {
            return null;
        }

    }

    public static TimeOnly? GetTimeOnly(string defaultValue = "00:00:00")
    {
        var  inout = AnsiConsole.Prompt(new TextPrompt<string>("[b]Time[/]:")
                .PromptStyle(PromptStyleColor)
                .DefaultValue(defaultValue)
                .AllowEmpty());

        if (TimeOnly.TryParse(inout, out var time))
        {
            return time;
        }
        else
        {
            return null;
        }
    }


    public static bool GetBool(string title = "Yes or no?")
    {
        return AnsiConsole.Prompt(
            new TextPrompt<bool>($"[b]{title}[/]:").PromptStyle(PromptStyleColor));
    }

    public static string GetYesNo()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<bool>("[b]Yes/No[/]:").PromptStyle(PromptStyleColor)) ? "Yes" : "No";
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

    public static string GetNewPassword(string title = "Password") =>
        AnsiConsole.Prompt(
            new TextPrompt<string>($"[b]{title}[/]?")
                .PromptStyle(PromptStyleColor)
                .AllowEmpty()
                .Secret()
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
                            : ValidationResult.Error("[red]Invalid password[/]")));

    public static bool TryGetValidPassword(string password, [NotNullWhen(true)] out string validPassword)
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
        => Continue(questionText, color).ToUpper() == "Y";

    public static List<string> MonthsSelection(int pageSize, string title = "Months") => AnsiConsole.Prompt
    (
        new MultiSelectionPrompt<string>()
            .PageSize(pageSize)
            .Required(false)
            .Title($"[b]{title}[/]?")
            .InstructionsText("[grey](Press [yellow]<space>[/] to toggle a month, [yellow]<enter>[/] to accept)[/] or [red]Enter[/] w/o any selections to cancel")
            .AddChoices(CurrentInfo!.MonthNames[..^1])
            .HighlightStyle(new Style(Color.White, Color.Black, Decoration.Invert))
    );


    /// <summary>
    /// Present a list where the user can select one or more items
    /// </summary>
    /// <typeparam name="T">Model type</typeparam>
    /// <param name="list">List of items</param>
    /// <param name="pageSize">How many items to show on the screen</param>
    /// <param name="title">What to display as the title</param>
    /// <returns></returns>
    /// <remarks>
    /// Might want to add a parameter for InstructionsText
    /// </remarks>
    public static List<T> GenericSelectionList<T>(List<T> list, int pageSize, string title) => AnsiConsole.Prompt
    (
        new MultiSelectionPrompt<T>()
            .PageSize(pageSize)
            .Required(false)
            .Title($"[b]{title}[/]?")
            .InstructionsText("[grey](Press [yellow]<space>[/] to toggle a selection, [yellow]<enter>[/] to accept)[/] or [red]Enter[/] w/o any selections to cancel")
            .AddChoices(list)
            .HighlightStyle(new Style(Color.White, Color.Black, Decoration.Invert))
    );
}