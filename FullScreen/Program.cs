using Spectre.Console;
using static FullScreen.Classes.SpectreConsoleHelpers;

namespace FullScreen
{
    partial class Program
    {
        static void Main(string[] args)
        {

            AnsiConsole.MarkupLine($"[{Color.Cyan1}]Full-screen[/] [{Color.Yellow}] .NET Version: {Environment.Version.ToString()}[/]");

            ExitPrompt();
        }
    }
}
