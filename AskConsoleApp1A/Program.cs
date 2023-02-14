namespace AskConsoleApp1A;

internal partial class Program
{
    static void Main(string[] args)
    {
        double length = Prompts.GetDouble("Please Enter Length:");
        double width = Prompts.GetDouble("Please Enter Width:");
        double height = Prompts.GetDouble("Please Enter Height:");
        Console.WriteLine();
        Console.WriteLine($"Length {length} Width {width} Height {height}");
        Console.ReadLine();
    }


}

internal class Prompts
{
    public static double GetDouble(string title) =>
        AnsiConsole.Prompt(
            new TextPrompt<double>($"[yellow]{title}[/]")
                .PromptStyle("white")
                .Validate(input => input switch
                {
                    < 1 => ValidationResult.Error("[white on red]1[/] [cyan]is min value[/]"),
                    _ => ValidationResult.Success(),
                }));
}