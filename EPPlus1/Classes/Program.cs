using System;
using System.Runtime.CompilerServices;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace EPPlus1
{
    partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample: Spectre.Console and EPPlus";
            W.SetConsoleWindowPosition(W.AnchorWindow.Center);
        }
    }
}





