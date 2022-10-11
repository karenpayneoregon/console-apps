using DependencyInjectionSimple.Models;
using Microsoft.Extensions.Options;

namespace DependencyInjectionSimple.Classes;

public class App
{
    private readonly ILogger<App> _logger;
    private readonly AppSettings _appSettings;

    public App(IOptions<AppSettings> appSettings, ILogger<App> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
    }

    public async Task Run(string[] args)
    {
        
        _logger.LogInformation("Starting...");
        
        AnsiConsole.MarkupLine("[green]Temp folder:[/] " + 
                               $"[b]{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _appSettings.TempDirectory)}[/]");

        _logger.LogInformation("Finished!");

        await Task.CompletedTask;
    }
}