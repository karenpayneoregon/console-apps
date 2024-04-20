namespace AskConsoleApp1A;

    internal partial class Program
    {
        static void Main()
        {
            AnsiConsole.MarkupLine("[bold yellow]Enter a number between 1 and 300 or 0 to quit[/]");
            var value = Prompts.GetInt(1,300);
            if (value < 1)
            {
                return;
            }
            var (message, result) = Operations.PerformCalculations(value);
            Console.Clear();
            AnsiConsole.MarkupLine($"[yellow]{message}[/] [cyan]{result}[/]");
            Console.ReadLine();
        }
    }

    internal class Prompts
    {
        public static int GetInt(int min, int max) =>
            AnsiConsole.Prompt(
                new TextPrompt<int>("[green]Enter a Number[/]")
                    .PromptStyle("green")
                    .DefaultValue(0)
                    .ValidationErrorMessage($"[red]Valid range is [/] [cyan]{min} to {max}[/]")
                    .Validate(value => value switch
                    {
                        < 1 => ValidationResult.Error($"[red]{min} is min value[/]"),
                        > 300 => ValidationResult.Error($"[red]{max} is max value[/]"),
                        _ => ValidationResult.Success(),
                    }));
    }

    internal class Operations
    {
        public static (string, string) PerformCalculations(int value) =>
            value switch
            {
                > 0 and <= 100 =>   ($"[white]{value}[/] between 0 and 100", $"Multiple {value * 2}"),
                > 100 and <= 200 => ($"[white]{value}[/] between 101 and 200", $"Divide {value / 2}"),
                > 200 and <= 300 => ($"[white]{value}[/] is between 201 and 300", $"Squared {value * value}"),
                _ => throw new Exception("Invalid value")
            };
    }
