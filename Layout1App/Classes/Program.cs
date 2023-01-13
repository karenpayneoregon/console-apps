using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace Layout1App;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample";
        
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    public static void ExitPrompt()
    {
        Render(new Rule($"[yellow]Press[/] [cyan]ENTER[/] [yellow]to exit the demo[/]").RuleStyle(Style.Parse("silver")).Centered());
        Console.SetCursorPosition(0,0);
        Console.ReadLine();
    }
    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
    }
}
