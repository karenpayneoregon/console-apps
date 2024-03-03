namespace MathApp;

internal partial class Program
{
    private static double firstNumber = 0;
    private static double secondNumber = 0;
    private static double result = 0;
    static void Main(string[] args)
    {
        firstNumber = Get("Please enter first number", 0);
        secondNumber = Get("Please enter second number", 0);
        
        MenuItem menuItem = new(); 

        while (menuItem.Id > -1)
        {
            Console.Clear();
            AnsiConsole.MarkupLine($"[yellow]First:[/] " +
                                   $"[green]{firstNumber}[/] " +
                                   $"[yellow]Second[/] [green]{secondNumber}[/] " +
                                   $"[cyan]Result[/][white] {result}[/]");

            menuItem = MenuConfiguration.Choices;
            switch (menuItem.Id)
            {
                case 1:
                    result = firstNumber + secondNumber;
                    break;
                case 2:
                    result = firstNumber - secondNumber;
                    break;
                case 3:
                    // multiple
                    result = firstNumber * secondNumber;
                    break;
                case 4:
                    result = firstNumber / secondNumber;
                    break;
            }
        }
    }
    internal static T Get<T>(string prompt, T defaultValue) =>
        AnsiConsole.Prompt(
            new TextPrompt<T>($"[white]{prompt}[/]")
                .PromptStyle("white")
                .DefaultValueStyle(new(Color.Yellow))
                .DefaultValue(defaultValue)
                .ValidationErrorMessage("[white on red]Invalid entry![/]"));
}

public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString() => Name;
}

public class MenuConfiguration
{
    public static MenuItem Choices =>
        AnsiConsole.Prompt(
            new SelectionPrompt<MenuItem>()
                .Title("[cyan]Select option or last item to cancel " +
                       "by using up/down arrows then press enter[/]")
                .AddChoices([
                    new MenuItem() { Id = 1, Name = "Add" },
                    new MenuItem() { Id = 2, Name = "Subtract" },
                    new MenuItem() { Id = 3, Name = "Multiply" },
                    new MenuItem() { Id = 4, Name = "Divide" },
                    new MenuItem() { Id = -1, Name = "Exit" }
                ])
                .HighlightStyle(new Style(Color.White, Color.Black, Decoration.Invert)));
}