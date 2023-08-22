namespace GetIntFrom1To10App;

internal partial class Program
{
    static void Main(string[] args)
    {
        var dictionary = Choices();

        Console.WriteLine($"You selected {dictionary[GetInt()]}");

        Console.ReadLine();
    }
    /// <summary>
    /// Text for int selected in <see cref="GetInt"/>
    /// </summary>
    /// <returns>Text for int selected</returns>
    private static Dictionary<int, string> Choices() 
        =>
        new()
        {
            { 1, "one" }, { 2, "two" }, { 3, "three" }, { 4, "four" }, { 5, "five" },
            { 6, "six" }, { 7, "seven" }, { 8, "eight" }, { 9, "nine" }, { 10, "ten" },
            { 11, "none" },
        };

    /// <summary>
    /// Provides a prompt for an int between two numbers with
    /// - colorization of screen output
    /// - Validation to ensure input is within set range
    /// - Range is 1 to 10 with 11 as an exit for aborting
    /// </summary>
    /// <returns>User selection</returns>
    private static int GetInt() 
        =>
        AnsiConsole.Prompt(new TextPrompt<int>(
                "Picked a [cyan]number[/] between [b]1[/] and [b]10[/] or [b]11[/] to exit")
                .PromptStyle("cyan")
                .ValidationErrorMessage("[red]That's not a valid value[/]")
                .Validate(validator: x => x switch
                {
                    <= 0 => ValidationResult.Error("[red]0 is min value[/]"),
                    >= 12 => ValidationResult.Error("[red]10 is max value[/]"),
                    _ => ValidationResult.Success(),
                }));
}