using System;
using Spectre.Console;

namespace CenterWindow
{
    partial class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.MarkupLine("[cyan]Press a key[/]");
            Console.ReadLine();
        }
    }
}
