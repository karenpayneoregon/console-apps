using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LoggingConsoleApp.Classes
{
    public class FileServices
    {
        private readonly ServiceProvider _provider;
        private readonly ILogger<FileServices> _logger;

        public FileServices()
        {
            
        }
        public FileServices(ServiceProvider provider)
        {
            _provider = provider;
            _logger = provider.GetService<ILoggerFactory>().CreateLogger<FileServices>();
        }
        public  void FindFile()
        {
            _logger.LogInformation($"Starting work in {nameof(FindFile)}");
        }
    }
}
