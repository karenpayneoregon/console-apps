using System.Collections.Generic;
using Spectre.Console;

namespace AskConsoleApp2.Classes
{
    public class Prompts
    {
        public static int PasswordLength() =>
            AnsiConsole.Prompt(
                new TextPrompt<int>("Enter the length of your password ([b]12 signs recommended[/]):")
                    .PromptStyle("yellow")
                    .DefaultValue(12)
                    .DefaultValueStyle(new Style(Color.Aqua))
                    .ValidationErrorMessage("[red]Must be integer[/]")
                    .Validate(value => value switch
                    {
                        <= 0 => ValidationResult.Error("[red]1 is min value[/]"),
                        >= 12 => ValidationResult.Error("[red]12 is max value[/]"),
                        _ => ValidationResult.Success(),
                    }));

        public static List<string> _choicesList => new List<string>()
        {
            "Uppercase letters?",
            "Other signs?",
            "Numbers?",
        };

        public static List<string> Choices() => AnsiConsole.Prompt
        (
            new MultiSelectionPrompt<string>()
                .Required(false)
                .Title("[cyan]Options[/]?")
                .InstructionsText("[grey](Press [yellow]<space>[/] to toggle a choice, [yellow]<enter>[/] to accept)[/] or [red]Enter[/] w/o any selections to cancel")
                .AddChoices(_choicesList)
                .HighlightStyle(new Style(Color.White, Color.Black, Decoration.Invert))
        );
    }
}
