using System;
using Spectre.Console;

namespace GetIntConsoleApp1
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            int value1 = Get("Please enter first number", 0);
            int value2 = Get("Please enter second number", 0);
            Console.WriteLine($"{value1,-5}{value2}");
            Console.WriteLine("Press ENTER to Exit");
            Console.ReadLine();
        }

        internal static T Get<T>(string prompt, T defaultValue) =>
            AnsiConsole.Prompt(
                new TextPrompt<T>($"[white]{prompt}[/]")
                    .PromptStyle("white")
                    .DefaultValueStyle(new(Color.Yellow))
                    .DefaultValue(defaultValue)
                    .ValidationErrorMessage("[white on red]Invalid entry![/]"));
    }
}