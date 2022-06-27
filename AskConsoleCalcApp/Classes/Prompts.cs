using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;

namespace AskConsoleCalcApp.Classes
{
    public class Prompts
    {
        public static List<string> MathOperators => new() { "+", "-", "x", "/" };
        public static List<string> QuestionOptions => new() { "Y", "N" };

        public static string GetOperator() =>
            AnsiConsole.Prompt(
                new TextPrompt<string>($"[white]Select an operator[/] {string.Join(",", MathOperators)}")
                    .PromptStyle("cyan")
                    .DefaultValue("+")
                    .ValidationErrorMessage($"[red]Please enter a valid operator[/] [white]{string.Join(",",MathOperators)}[/] [red]or press ENTER for default[/]")
                    .Validate(text => MathOperators.Contains(text, StringComparer.CurrentCultureIgnoreCase) switch
                    {
                        false => ValidationResult.Error("[red]Must be less than 2001[/]"),
                         _    => ValidationResult.Success()
                    }));


        public static int GetInt(string text) =>
            AnsiConsole.Prompt(
                new TextPrompt<int>($"[white]Enter {text}[/]")
                    .PromptStyle("cyan")
                    .ValidationErrorMessage("[red]That's not a valid integer[/]"));

        public static string Continue(string questionText) =>
            AnsiConsole.Prompt(
                new TextPrompt<string>($"[white]Continue[/] {string.Join(",", QuestionOptions)}")
                    .PromptStyle("cyan")
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
        /// <returns>true or false</returns>
        /// <remarks>
        /// There is also AnsiConsole.Confirm but provides no option to
        /// change text color for (y/n)
        /// </remarks>
        public static bool AskConfirmation(string questionText)
        {
            return Continue(questionText).ToUpper() == "Y"; // AnsiConsole.Confirm("[lime]Perform another calculation?[/]");
        }

    }
}
