using System.Runtime.CompilerServices;
using Spectre.Console;


namespace NorthWind2020ConsoleApp.Classes;

public class Colored
{
    [ModuleInitializer]
    public static void InitColored()
    {
        AnsiConsole.MarkupLine("[cyan]Reading employee information[/]");
    }
}