using System.Runtime.CompilerServices;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace MenuConsoleApp;

partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample - Spectre.Console menu with EF Core";
        W.SetConsoleWindowPosition(W.AnchorWindow.Center);
    }
}