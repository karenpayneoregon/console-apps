using System;
using System.Text.RegularExpressions;
using System.Text;
using Questions.Classes;
using Spectre.Console;
using Microsoft.VisualBasic;

namespace Questions
{
    partial class Program
    {
        static void Main(string[] args)
        {
            string a = "BMW_1233;CHE_345555;MER_99900;09090;BMW_9999;BMW_1212;CHE_9999";
            string[] split = a.Split(new Char[] { ';', '_' });
            Console.ReadLine();
            //while (true)
            //{
            //    Console.Clear();

            //    var menuItem = AnsiConsole.Prompt(MenuOperations.SelectionPrompt());
            //    if (menuItem.Index != -1)
            //    {
            //        AnsiConsole.MarkupLine($"[b]{menuItem.Name}[/] index is [b]{menuItem.Index}[/]");
            //        Console.ReadLine();
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
        }
    }
}
