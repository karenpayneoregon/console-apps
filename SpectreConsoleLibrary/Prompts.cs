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
    public static string PromptColor { get; set; } = "b";

    /// <summary>
    /// Ask for a first name
    /// </summary>
    /// <param name="allowEmpty">allows an empty string to return</param>
    public static string GetFirstName(bool allowEmpty, string title = "Enter first name")
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
    /// Ask for a first name
    /// </summary>
    /// <param name="allowEmpty">allows an empty string to return</param>
    /// <param name="title">prompt to display</param>
    public static string GetMiddleName(bool allowEmpty, string title = "Enter middle name")
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
    /// Ask for a last name
    /// </summary>
    /// <param name="allowEmpty">allows an empty string to return</param>
    /// <param name="title">prompt to display</param>
    public static string GetLastName(bool allowEmpty, string title = "Enter last name")
    {
        return allowEmpty
            ? AnsiConsole.Prompt(
                new TextPrompt<string>($"[{PromptColor}]{title}[/]:")
                    .PromptStyle(PromptStyleColor)
                    .AllowEmpty())
            : AnsiConsole.Prompt(
                new TextPrompt<string>($"[{PromptColor}]{title}[/]:")
                    .PromptStyle(PromptStyleColor));
    }

    /// <summary>
    /// Ask for an int with validation, with optional prompt
    /// </summary>
    /// <returns>an int</returns>
    public static int GetInt(string title = "Enter a integer")
    {
        return AnsiConsole.Prompt(
            new TextPrompt<int>($"[{PromptColor}]{title}[/]:")
                .PromptStyle(PromptStyleColor)
                .ValidationErrorMessage("[red]That's not a number[/]"));
    }

    /// <summary>
    /// Ask for a decimal with validation, with optional prompt
    /// </summary>
    /// <returns>a decimal</returns>
    public static decimal GetDecimal(string title = "Enter a decimal")
    {
        return AnsiConsole.Prompt(
            new TextPrompt<decimal>($"[{PromptColor}]{title}[/]")
                .PromptStyle(PromptStyleColor)
                .DefaultValue(1m));
    }

    /// <summary>
    /// Ask for a double with validation, with optional prompt
    /// </summary>
    /// <returns>a double</returns>
    public static double GetDouble(string title = "Enter a double")
    {
        return AnsiConsole.Prompt(
            new TextPrompt<double>($"[{PromptColor}]{title}[/]")
                .PromptStyle(PromptStyleColor)
                .DefaultValue(1));
    }

    public static int GetIntFrom1To10()
    {
        const int maxValue = 10;
        return AnsiConsole.Prompt(
            new TextPrompt<int>($"[{PromptColor}]Enter a number[/] between [b]1[/] and [b]10[/]")
                .PromptStyle(PromptStyleColor)
                .ValidationErrorMessage("[red]That's not a valid entry[/]")
                .Validate(item => item switch
                {
                    <= 0 => ValidationResult.Error("[red]1 is min value[/]"),
                    >= maxValue => ValidationResult.Error($"[red]{maxValue} is max value[/]"),
                    _ => ValidationResult.Success(),
                }));
    }

    /// <summary>
    /// Prompt for a birth date, with optional prompt
    /// </summary>
    /// <returns>A nullable DateTime</returns>
    public static DateTime? GetBirthDate(string title = "Enter your birth date")
    {
        /*
         * doubtful there is a birth day for the current person
         * but if checking say a parent or grand-parent this will not allow before 1900
         */
        const int minYear = 1900;

        return AnsiConsole.Prompt(
            new TextPrompt<DateTime>($"[{PromptColor}]{title}[/]:")
                .PromptStyle(PromptStyleColor)
                .ValidationErrorMessage("[red]Please enter a valid date or press ENTER to not enter a date[/]")
                .Validate(dateTime => dateTime.Year switch
                {
                    <= minYear => ValidationResult.Error($"[red]Year must be greater than {minYear}[/]"),
                    _ => ValidationResult.Success(),
                })
                .AllowEmpty());
    }


    /// <summary>
    /// Prompt for a date, with optional prompt
    /// </summary>
    /// <returns>A nullable DateTime</returns>
    public static DateTime? GetDateTime(string title = "Enter a date")
    {
        return AnsiConsole.Prompt(
            new TextPrompt<DateTime>($"[{PromptColor}]{title}[/]:")
                .PromptStyle(PromptStyleColor)
                .ValidationErrorMessage("[red]Please enter a valid date or press ENTER to not enter a date[/]")
                .AllowEmpty());
    }



    /// <summary>
    /// Prompt for a DateOnly, with optional prompt and default as 
    /// </summary>
    /// <returns>A nullable DateOnly</returns>
    public static DateOnly? GetDateOnly(DateOnly? defaultDate)
    {
        var defaultValue = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        if (defaultDate.HasValue)
        {
            defaultValue = defaultDate.Value;
        }

        var input = AnsiConsole.Prompt(
            new TextPrompt<string>($"[{PromptColor}]Date[/]:")
                .PromptStyle(PromptStyleColor)
                .DefaultValue(defaultValue.ToString())
                .ValidationErrorMessage("[red]Please enter a valid date or press ENTER to not enter a date[/]")
                .AllowEmpty());

        return DateOnly.TryParse(input, out var date) ? date : null;
    }


    /// <summary>
    /// Prompt for a TimeOnly with default as 00:00:00
    /// </summary>
    /// <returns>A nullable TimeOnly</returns>
    public static TimeOnly? GetTimeOnly(string defaultValue = "00:00:00")
    {
        var  inout = AnsiConsole.Prompt(new TextPrompt<string>($"[{PromptColor}]Time[/]:")
                .PromptStyle(PromptStyleColor)
                .DefaultValue(defaultValue)
                .AllowEmpty());

        return TimeOnly.TryParse(inout, out var time) ? time : null;
    }

    /// <summary>
    /// Prompt for a bool
    /// </summary>
    /// <param name="title">text to present</param>
    /// <returns>bool</returns>
    public static bool GetBool(string title = "Yes or no?")
    {
         Style highLightStyle = new(Color.Cyan1, Color.Black, Decoration.None);
         SelectionPrompt<string> items = new()
         {
             HighlightStyle = highLightStyle, 
             Title = title
         };

        items.AddChoices("Yes", "No");
        return AnsiConsole.Prompt(items) == "Yes";
    }

    public static string GetYesNo()
    {
        return AnsiConsole.Prompt(
            new TextPrompt<bool>($"[{PromptColor}]Yes/No[/]:").PromptStyle(PromptStyleColor)) ? "Yes" : "No";
    }

    /// <summary>
    /// Get user name suitable for a login
    /// </summary>
    /// <param name="allowEmpty">allows an empty string</param>
    public static string GetUserName(bool allowEmpty)
    {
        return allowEmpty
            ? AnsiConsole.Prompt(
                new TextPrompt<string>($"[{PromptColor}]First name[/]")
                    .PromptStyle(PromptStyleColor)
                    .AllowEmpty())
            : AnsiConsole.Prompt(
                new TextPrompt<string>($"[{PromptColor}]First name[/]:")
                    .PromptStyle(PromptStyleColor));
    }


    /// <summary>
    /// Get a password without exposing input
    /// </summary>
    public static string GetPassword() =>
        AnsiConsole.Prompt(
            new TextPrompt<string>($"[{PromptColor}]Password[/]:")
                .PromptStyle("grey50")
                .Secret()
                .DefaultValueStyle(new Style(Color.Aqua)));

    /// <summary>
    /// Get a new password using rules from <seealso cref="ValidatePassword"/>
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    public static string GetNewPassword(string title = "Password") =>
        AnsiConsole.Prompt(
            new TextPrompt<string>($"[{PromptColor}]{title}[/]?")
                .PromptStyle(PromptStyleColor)
                .AllowEmpty()
                .Secret()
                .Validate(ValidatePassword)
                .ValidationErrorMessage("[red]Entry does not match rules for creating a new password[/]"));


    /// <summary>
    /// NuGet package to validate a string via rules
    /// </summary>
    /// <param name="password">string to validate</param>
    /// <returns></returns>
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
                new TextPrompt<string>($"[{PromptColor}]What's the username?[/]")
                    .Validate(username
                        => !string.IsNullOrWhiteSpace(username)
                            ? ValidationResult.Success()
                            : ValidationResult.Error("[yellow]Invalid username[/]")));


    public static string AskPasswordIfMissing(string current)
        => TryGetValidPassword(current, out var validPassword)
            ? validPassword
            : AnsiConsole.Prompt(
                new TextPrompt<string>($"[{PromptColor}]What's the password?[/]")
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
            .Title($"[{PromptColor}]{title}[/]?")
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
            .Title($"[{PromptColor}]{title}[/]")
            .InstructionsText("[grey](Press [yellow]<space>[/] to toggle a selection, [yellow]<enter>[/] to accept)[/] or [red]Enter[/] w/o any selections to cancel")
            .AddChoices(list)
            .HighlightStyle(new Style(Color.White, Color.Black, Decoration.Invert))
    );
}