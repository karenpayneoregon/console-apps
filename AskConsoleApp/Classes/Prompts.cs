using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Globalization.DateTimeFormatInfo;
using Spectre.Console;

namespace AskConsoleApp.Classes
{
    public class Prompts
    {
        /// <summary>
        /// Example to get a date and allow no entry with custom error message
        /// </summary>
        public static DateTime? GetBirthDate() =>
            AnsiConsole.Prompt(
                new TextPrompt<DateTime>("What is your [white]birth date[/]?")
                    .PromptStyle("yellow")
                    .ValidationErrorMessage("[red]Please enter a valid date or press ENTER to not enter a date[/]")
                    .Validate(dateTime => dateTime.Year switch
                    {
                          >= 2001 => ValidationResult.Error("[red]Must be less than 2001[/]"),
                        _ => ValidationResult.Success(),
                    })
                    .AllowEmpty());

        /// <summary>
        /// Ask for first name with custom validation error text
        /// </summary>
        public static string GetFirstName() =>
            AnsiConsole.Prompt(
                new TextPrompt<string>("[white]First name[/]?")
                    .PromptStyle("yellow")
                    .Validate(value => value.Length switch
                    {
                        < 3 => ValidationResult.Error("[red]Must have at least three characters[/]"),
                        _ => ValidationResult.Success(),
                    })
                    .ValidationErrorMessage("[red]Please enter your first name[/]"));


        /// <summary>
        /// Ask for last name with custom validation error text
        /// </summary>
        public static string GetLastName() =>
            AnsiConsole.Prompt(
                new TextPrompt<string>("[white]Last name[/]?")
                    .PromptStyle("yellow")
                    .ValidationErrorMessage("[red]Please enter your last name[/]"));


        /// <summary>
        /// Get an int with validation rather than the default validation message
        /// </summary>
        public static int GetInt() =>
            AnsiConsole.Prompt(
                new TextPrompt<int>("Enter a [green]number[/] between [b]1[/] and [b]10[/]")
                    .PromptStyle("green")
                    .ValidationErrorMessage("[red]That's not a valid age[/]")
                    .Validate(age => age switch
                    {
                        <= 0 => ValidationResult.Error("[red]1 is min value[/]"),
                        >= 10 => ValidationResult.Error("[red]10 is max value[/]"),
                        _ => ValidationResult.Success(),
                    }));

        /// <summary>
        /// Present a list of months which allows one or more months to be selected
        /// Selections are optional by using .Required(false)
        /// </summary>
        /// <returns></returns>
        public static List<string> GetFavoriteMonths() => AnsiConsole.Prompt
        (
            new MultiSelectionPrompt<string>()
                .PageSize(12)
                .Required(false)
                .Title("What are your [cyan]favorite months[/]?")
                .InstructionsText("[grey](Press [yellow]<space>[/] to toggle a month, [yellow]<enter>[/] to accept)[/] or [red]Enter[/] w/o any selections to cancel")
                .AddChoices(CurrentInfo!.MonthNames[..^1])
                .HighlightStyle(new Style(Color.White, Color.Black, Decoration.Invert))
        );

    }
}
