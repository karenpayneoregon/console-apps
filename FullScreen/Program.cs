using System;
using Spectre.Console;

namespace FullScreen
{
    partial class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.MarkupLine($"[cyan]Full-screen[/]");
            Console.ReadLine();
        }
    }
}
