using System;
using System.Runtime.CompilerServices;
using W = ConsoleHelperLibrary.Classes.WindowUtility;
namespace BasicConsoleApp3
{
    class InitApp
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample: Top-Level";

            W.SetConsoleWindowPosition(W.AnchorWindow.Center);


        }
    }
}
