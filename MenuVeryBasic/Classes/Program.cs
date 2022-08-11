using System;
using System.Runtime.CompilerServices;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace MenuVeryBasic
{
    partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.SetWindowSize(40, 10);
            Console.Title = "Code sample";
            W.SetConsoleWindowPosition(W.AnchorWindow.Center);
        }
    }
}





