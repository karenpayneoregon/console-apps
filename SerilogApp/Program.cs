using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SpectreConsole;

namespace SerilogApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.SpectreConsole("{Timestamp:HH:mm:ss} [{Level:u4}] {Message:lj}{NewLine}{Exception}", minLevel: LogEventLevel.Verbose)
            .MinimumLevel.Verbose()
            .CreateLogger();

        // if appsettings.json is what you like...
        //var configuration = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsettings.json")
        //    .Build();

        //Log.Logger = new LoggerConfiguration()
        //    .ReadFrom.Configuration(configuration)
        //    .CreateLogger();


        Log.Verbose("Verbose level example with {0}", "parameter");
        Log.Debug("Debug level example with {0}", "parameter");
        Log.Information("Information level example with {0}", "parameter");
        Log.Warning("Warning level example with {0}", "parameter");

        try
        {
            File.ReadAllLines("NotHere");
        }
        catch (Exception exception)
        {
            Log.Error(exception, "Error level example with {0}", "parameter");
        }

 
        Console.ReadLine();
    }
}