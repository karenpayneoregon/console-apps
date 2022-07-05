using System;
using Spectre.Console;

namespace ExceptionsConsoleAppGlobal
{
    partial class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.MarkupLine("Press [b]ENTER[/] to throw and catch an exception");
            Console.ReadLine();
            var boom = args[12];
        }
    }
}
