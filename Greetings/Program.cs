using McMaster.Extensions.CommandLineUtils;

namespace Greetings;

class Program
{
    public static int Main(string[] args)
    {
        return CommandLineApplication.Execute<Program>(args);
    }

    [Option("-t|--times")]
    [Range(0, 10)]
    [Required]
    public int Count { get; }

    public void OnExecute()
    {
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine($"[white on red]Greetings[/][red on red]{new string('.',12)}[/]");
        AnsiConsole.MarkupLine($"[yellow on red]Iterating[/][red on red]{new string('.',12)}[/]");
        for (var index = 0; index < Count; index++)
        {
            AnsiConsole.MarkupLine($"\t[white on red]{(index +1), -3:D2} iteration[/]");

        }

    }
}