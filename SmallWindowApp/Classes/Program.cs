using System;
using System.Runtime.CompilerServices;
using W = ConsoleHelperLibrary.Classes.WindowUtility;
using D = ConsoleHelperLibrary.Classes.WriteUtility;

// ReSharper disable once CheckNamespace
namespace SmallWindowApp
{
    partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample";
            Console.SetWindowSize(40, 10);
            W.SetConsoleWindowPosition(W.AnchorWindow.Center);
            D.CenterLines("Greetings to this cool demo", 
                "Each line is centered on the screen.",
                "Useful for a intro screen",
                "Press a key to continue!");
            Console.CursorVisible = false;
        }
    }
}





