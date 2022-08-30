using System.Runtime.CompilerServices;
using Spectre.Console;
using W = ConsoleHelperLibrary.Classes.WindowUtility;
namespace ConsoleApp1;

partial class Program
{
    public static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }
    public static void Header()
    {
        Render(new Rule().RuleStyle(Style.Parse("white")).HeavyBorder().LeftAligned());

        AnsiConsole.Write(new FigletText("Running").Centered().Color(Color.Aquamarine1));

        Render(new Rule().RuleStyle(Style.Parse("white")).HeavyBorder().LeftAligned());
    }

    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample - BackgroundService";
        W.SetConsoleWindowPosition(W.AnchorWindow.Center);
    }

}