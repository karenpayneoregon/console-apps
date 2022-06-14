using System;
using LoggingConsoleApp.Classes;
using LoggingConsoleApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Targets;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace LoggingConsoleApp
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            var fooService = serviceProvider.GetService<ICommonService>();
            fooService!.Execute();

            var fileService = new FileServices(serviceProvider);
            fileService.FindFile();

            _logger.LogInformation("Exiting application...");

            Console.WriteLine("Done");
            NLog.LogManager.Shutdown();
            Console.ReadLine();

        }
    }
}
