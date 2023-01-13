using System;
using System.Collections.Generic;
using System.Linq;
using AskConsoleApp4.Classes;
using Spectre.Console;

namespace AskConsoleApp4
{
    partial class Program
    {
        static void Main(string[] args)
        {
            int intValue = Prompts.GetInt();
            decimal decimalValue = Prompts.GetDecimal();

            AnsiConsole.MarkupLine($"[cyan]int:[/] {intValue}");
            AnsiConsole.MarkupLine($"[cyan]decimal:[/] {decimalValue}");

            Console.ReadLine();
        }

    }
}
