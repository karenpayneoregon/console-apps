namespace AskConsoleApp6;

internal partial class Program
{
    static void Main(string[] args)
    {
        string[] prompts =
        {
            "first",
            "second",
            "third"
        };

        AnsiConsole.MarkupLine("[white]Please enter three numbers[/]");
        List<int> list = new List<int>();

        for (int index = 0; index < 3; index++)
        {
            int value = AnsiConsole.Prompt(
                new TextPrompt<int>($"[cyan]Enter {prompts[index]} number[/]")
                    .PromptStyle("yellow")
                    .ValidationErrorMessage("[white on red]Please enter a number[/]")
                    .DefaultValue(0));
            ;

            list.Add(value);

            Console.Clear();
        }

        AnsiConsole.MarkupLine($"[white on blue]Total is {list.Sum()}[/]");

        Console.ReadLine();
    }
}