using System;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using W = ConsoleHelperLibrary.Classes.WindowUtility;
using PanoramicData.ConsoleExtensions;

// ReSharper disable once CheckNamespace
namespace PanoramicDataLogging
{
    partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample";
            W.SetConsoleWindowPosition(W.AnchorWindow.Center);
            LogError();
        }

        public static void LogError()
        {
            var consoleLogger = new ConsoleLogger(new ConsoleLoggerOptions
            {
                TraceColor = ConsoleColor.DarkYellow,
                LogLevel = LogLevel.Debug, 
                ErrorColor = ConsoleColor.Magenta
            });


            consoleLogger.LogError(new  FileNotFoundException("Some file does not exists..."), 
                "Failure occurred at {DateTime:yyyy-MM-dd}", DateTime.UtcNow);

            consoleLogger.LogDebug(new FileNotFoundException("Some file does not exists..."),
                "Failure occurred at {DateTime:yyyy-MM-dd}", DateTime.UtcNow);

        }
    }
}





