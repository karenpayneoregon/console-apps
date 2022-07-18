using System;
using AskConsoleApp5.Classes;
using AskConsoleApp5.Models;
using Spectre.Console;

namespace AskConsoleApp5
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Language language = MenuChoices.LanguageChoice;
            if (language.Id == -1)
            {
                return;
            }
            
            AnsiConsole.MarkupLine($"[yellow]{language.Title}[/]");
            AnsiConsole.MarkupLine("[b]Press a key to continue[/]");

            Console.ReadLine();

        }
    }
}
