using System;
using System.Runtime.CompilerServices;
using Spectre.Console;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace WelcomeApp
{
    partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample";

            Console.SetWindowSize(40, 10);
            W.SetConsoleWindowPosition(W.AnchorWindow.Center);
            
            Console.CursorVisible = false;
            PrintLinesInCenter("Welcome", "To working with console apps", "Press a key to continue");
            Console.ReadLine();
            Console.CursorVisible = true;
            AnsiConsole.Clear();

        }
        private static void PrintLinesInCenter(params string[] lines)
        {
            int verticalStart = (Console.WindowHeight - lines.Length) / 2;
            int verticalPosition = verticalStart;
            for (var index = 0; index < lines.Length; index++)
            {
                var line = lines[index];
                int horizontalStart = (Console.WindowWidth - line.Length) / 2;
                Console.SetCursorPosition(horizontalStart, verticalPosition);
                Console.Write(line);
                ++verticalPosition;
            }
        }
    }
}





