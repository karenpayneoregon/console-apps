using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Spectre.Console;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace AskConsoleApp
{
    partial class Program
    {

        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample";

            W.ShowWindow(W.GetConsoleWindow(), 3);

            AnsiConsole.Write(
                new Panel(new Text("Various prompt examples").Centered())
                    .Expand()
                    .SquareBorder()
                    .BorderStyle(new Style(Color.DarkViolet))
                    .Header("[white on DarkViolet]About[/]")
                    .HeaderAlignment(Justify.Center));
        }

    }
}





