using LoggingConsoleApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace LoggingConsoleApp.Classes
{
    public class Logging
    {
        public static (ServiceProvider, ILogger<Program>) Configuration()
        {

            var serviceProvider = new ServiceCollection()
                .AddSingleton<ICommonService, FooService>()
                .AddLogging(builder =>
                {
                    builder.SetMinimumLevel(LogLevel.Trace);
                    builder.AddNLog(new NLogProviderOptions
                    {
                        CaptureMessageTemplates = true,
                        CaptureMessageProperties = true
                    });
                })
                .BuildServiceProvider();


            var _logger = serviceProvider
                .GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            _logger.LogInformation("Starting application...");

            return (serviceProvider, _logger);

        }
    }
}
