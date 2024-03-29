﻿using DependencyInjectionSimple.Data;
using DependencyInjectionSimple.Models;
using Microsoft.Extensions.Configuration;

namespace DependencyInjectionSimple.Classes
{
    public class Utilities
    {
        /// <summary>
        /// Read sections from appsettings.json
        /// </summary>
        public static IConfigurationRoot ConfigurationRoot() =>
            new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

        public static ServiceCollection ConfigureServices()
        {
            static void ConfigureService(IServiceCollection services)
            {
                services.AddLogging(builder =>
                {
                    builder.AddConsole();
                    builder.AddDebug();
                    builder.AddConfiguration(ConfigurationRoot().GetSection("Logging"));
                });

               
                services.Configure<AppSettings>(ConfigurationRoot().GetSection(nameof(App)));
                services.AddDbContext<PizzaContext>(options =>
                    options.UseSqlServer(
                        ConfigurationRoot().GetSection(ConnectionStrings.Location).Value));


                services.AddTransient<App>();
                services.AddTransient<DataAccess>();
            }

            var services = new ServiceCollection();
            ConfigureService(services);
            return services;
        }
    }
}
