using System;
using Questions.Classes;
using Spectre.Console;

namespace Questions
{
    partial class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                var menuItem = AnsiConsole.Prompt(MenuOperations.SelectionPrompt());
                if (menuItem.Index != -1)
                {
                    AnsiConsole.MarkupLine($"[b]{menuItem.Name}[/] index is [b]{menuItem.Index}[/]");
                    Console.ReadLine();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
