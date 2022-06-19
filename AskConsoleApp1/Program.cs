using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;

namespace AskConsoleApp1
{
    partial class Program
    {
        private static List<int> _list = new List<int>();

        static void Main(string[] args)
        {
            int count = GetCount();

            if (count == 0)
            {
                AnsiConsole.MarkupLine("[white]Press ENTER to quit[/]");
                Console.ReadLine();
                return;
            }

            for (int index = 0; index < count; index++)
            {
                _list.Add(GetInt(index));
            }

            _list = _list.OrderBy(x => x).ToList();
            
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[skyblue1]Results[/]");
            AnsiConsole.MarkupLine($"[skyblue1]Sorted:[/] {string.Join(",", _list)}");

            AnsiConsole.MarkupLine($"[skyblue1]   Sum:[/] {_list.Sum()}");
            AnsiConsole.MarkupLine($"[skyblue1]   Min:[/] {_list.Min()}");
            AnsiConsole.MarkupLine($"[skyblue1]   Max:[/] {_list.Max()}");

            AnsiConsole.MarkupLine("[white]Press ENTER to quit[/]");
            Console.ReadLine();
        }

        /// <summary>
        /// Get value, if already in list indicate a duplicate can
        /// not be added
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int GetInt(int index) =>
            AnsiConsole.Prompt(
                new TextPrompt<int>($"[skyblue2]Enter a number for[/] [yellow]{index +1}[/]")
                    .PromptStyle("white")
                    .ValidationErrorMessage("\t[violet]Not a number, try again!!![/]")
                    .Validate(current => _list.Contains(current) ?
                        ValidationResult.Error($"{current}[red]Duplicates not permitted[/]") : 
                        ValidationResult.Success())
                    );

        /// <summary>
        /// Ask for how many elements for the list container
        /// </summary>
        public static int GetCount() =>
            AnsiConsole.Prompt(
                new TextPrompt<int>("[skyblue2]Enter element count?[/] ([yellow on red]enter 0 to abort[/])")
                    .PromptStyle("white")
                    .ValidationErrorMessage("[violet]Not a valid int[/]")
                );
    }
}
