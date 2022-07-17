using System;
using System.Runtime.CompilerServices;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace TopRightPosition
{
    partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample - Top right";
            W.SetConsoleWindowPosition(W.AnchorWindow.Top | W.AnchorWindow.Right);
        }
    }
}





