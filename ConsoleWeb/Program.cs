using Microsoft.AspNetCore.Hosting;
using Spectre.Console;

namespace ConsoleWeb
{
    class Program
    {
        static void Main(string[] args)
        {

            AnsiConsole.MarkupLine($"[yellow]go to[/] [b]http://localhost:5000/[/] for viewing");
            AnsiConsole.WriteLine();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            host.Run();

        }
    }
}
