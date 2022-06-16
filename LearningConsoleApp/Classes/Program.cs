using System;
using System.Runtime.CompilerServices;
using Spectre.Console;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace LearningConsoleApp
{
    partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample";
            W.ShowWindow(W.GetConsoleWindow(), 3);

            //var panel = new Panel("[chartreuse2_1]Uncomment one at a time a method and run the method[/]")
            //{
            //    Border = BoxBorder.Rounded,
                
            //};

            //panel.Header($" [white]Important[/] ", Justify.Left);

            //AnsiConsole.Write(panel);
        }
    }
}





