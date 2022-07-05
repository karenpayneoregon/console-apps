using System;
using System.Runtime.CompilerServices;
using ExceptionsConsoleAppGlobal.Classes;
using W = ConsoleHelperLibrary.Classes.WindowUtility;


// ReSharper disable once CheckNamespace
namespace ExceptionsConsoleAppGlobal
{
    partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            W.SetConsoleWindowPosition(W.AnchorWindow.Center);
            Console.Title = "Code sample: Unhandled Exception Trapper";
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
        }
        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
           
            ExceptionHelpers.ColorStandard((Exception)e.ExceptionObject);
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
