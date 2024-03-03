using System.Runtime.CompilerServices;
using ExceptionsConsoleAppGlobal1.Classes;
using Spectre.Console;
using W = ConsoleHelperLibrary.Classes.WindowUtility;


// ReSharper disable once CheckNamespace
namespace ExceptionsConsoleAppGlobal1;

partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        W.SetConsoleWindowPosition(position: W.AnchorWindow.Center);
        Console.Title = "Code sample";

        AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
    }
    static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
    {
           
        ((Exception)e.ExceptionObject).ColorStandard();

        Console.WriteLine();
        AnsiConsole.MarkupLine(value: "[u]Press Enter to continue[/]");
        Console.ReadLine();
        Environment.Exit(exitCode: 1);
    }

    static string CenterText(string input, int maxLength, char c)
    {
        input = input.Insert(startIndex: input.Length, value: " ").Insert(startIndex: 0, value: " ");

        return input.Length > maxLength
            ? input.Substring(startIndex: 0, length: maxLength - 3).Insert(startIndex: maxLength - 3, value: " ").PadLeft(totalWidth: maxLength - 1, paddingChar: c)
                .PadRight(totalWidth: maxLength, paddingChar: c)
            : input.PadLeft(
                    totalWidth: input.Length + ((maxLength - input.Length) / 2) +
                                (((maxLength - input.Length) % 2 != 1) ? 0 : 1), paddingChar: c)
                .PadRight(totalWidth: input.Length + (maxLength - input.Length), paddingChar: c);
    }

    private static Table CreateTable(string title)
    {
        var table = new Table();
        table.AddColumn(column: "X");
        table.AddRow(columns: $"[white on red]{title}[/]");
        table.HideHeaders();
        table.BorderColor(color: Color.Red);
        
        table.Width = 40;

        return table;
    }
}