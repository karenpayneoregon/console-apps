using System;
using System.Runtime.CompilerServices;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace BottomRightPositioning
{
    partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample - bottom right";
            W.SetConsoleWindowPosition(W.AnchorWindow.Bottom | W.AnchorWindow.Right);
        }
    }
}





