using System;
using System.Runtime.CompilerServices;
using LoggingConsoleApp.Classes;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace LoggingConsoleApp
{
    public partial class Program
    {
        private static  ServiceProvider serviceProvider;
        private static  ILogger<Program> _logger;
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample: Logging";
            W.SetConsoleWindowPosition(W.AnchorWindow.Center);

            var (provider, logger) = Logging.Configuration();
            serviceProvider = provider;
            _logger = logger;
        }
    }
}





