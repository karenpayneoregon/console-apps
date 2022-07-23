using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace ColonySimulatorApp.Classes
{
    public class Prompts
    {
        public static int GetFarmerCount() =>
            AnsiConsole.Prompt(
                new TextPrompt<int>("How many [green]farmers[/]")
                    .PromptStyle("green")
                    .ValidationErrorMessage("[red]That's not a valid count[/]")
                    .Validate(count => count switch
                    {
                        <= 0 => ValidationResult.Error("[red]1 is min value[/]"),
                        _ => ValidationResult.Success(),
                    }));
    }
}
