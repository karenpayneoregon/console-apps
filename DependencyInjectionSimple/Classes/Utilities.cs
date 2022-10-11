using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationLibrary.Classes;
using DependencyInjectionSimple.Data;
using Microsoft.Extensions.Configuration;

namespace DependencyInjectionSimple.Classes
{
    public class Utilities
    {
        /// <summary>
        /// Read sections from appsettings.json
        /// </summary>
        public static IConfigurationRoot ConfigurationRoot()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            return configuration;
        }

        public static ServiceCollection ConfigureServices()
        {
            static void ConfigureService(IServiceCollection services)
            {
                services.AddLogging(builder =>
                {
                    builder.AddConsole();
                    builder.AddDebug();
                    builder.AddConfiguration(Utilities.ConfigurationRoot().GetSection("Logging"));
                });

                services.Configure<AppSettings>(Utilities.ConfigurationRoot().GetSection("App"));

                services.AddDbContext<PizzaContext>(options =>
                    options.UseSqlServer(ConfigurationHelper.ConnectionString()));


                services.AddTransient<App>();
                services.AddTransient<DataAccess>();
            }

            var services = new ServiceCollection();
            ConfigureService(services);
            return services;
        }
    }
}
