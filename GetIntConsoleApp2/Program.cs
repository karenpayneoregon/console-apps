namespace GetIntConsoleApp2;

internal partial class Program
{
    static void Main(string[] args)
    {
        int answer = GetNumber();
        Console.WriteLine(answer.ToString());
        Console.ReadLine();
    }

    private const int Max = 99999;
    public static int GetNumber() =>
        AnsiConsole.Prompt(
            new TextPrompt<int>("[white on blue]Enter a number:[/]")
                .PromptStyle("cyan")
                .ValidationErrorMessage("[red]Must be integer[/]")
                .Validate(value => value switch
                {
                    < 0 or > Max => ValidationResult.Error($"[red]Must be greater than 0 and less than {Max}[/]"),
                    _ => ValidationResult.Success(),
                }));
}