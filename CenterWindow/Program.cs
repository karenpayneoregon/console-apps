using System;
using Spectre.Console;
using UtilityLibrary.Classes;

namespace CenterWindow
{
    partial class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.MarkupLine($"[yellow]{Howdy.TimeOfDay()}[/] [cyan]Press a key[/]");
            Console.ReadLine();
        }
    }
}
