namespace MenuFuelApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        MenuItem menuItem = AnsiConsole.Prompt(MenuOperations.MainMenu());
        AnsiConsole.MarkupLine(menuItem.Id > -1
            ? $"Fuel type [cyan]{menuItem.Text}[/] at " +
              $"[cyan]{menuItem.Price:C}[/] Press a key to exit"
            : "[yellow]Nothing selected[/] Press a key to exit");

        Console.ReadLine();
    }
}
public class MenuItem
{
    public int Id { get; set; }
    public string Text { get; set; }
    public double Price { get; set; }
    // what to display in menu
    public override string ToString() => Text;
}

class MenuOperations
{
    // Style for menu
    private static Style HighLightStyle => 
        new(Color.LightGreen, 
            Color.Black, Decoration.None);
    
    // Create menu with mocked items
    public static SelectionPrompt<MenuItem> MainMenu()
    {
        SelectionPrompt<MenuItem> menu = new()
        {
            HighlightStyle = HighLightStyle
        };

        menu.Title("Select a [B]fuel type[/]");
        menu.AddChoices(MockedItems());

        return menu;
    }
    // For a real app, load items from a file
    public static List<MenuItem> MockedItems()
    {
        return new List<MenuItem>()
        {
            new() { Id = 0,  Text = "A100", Price = 3.99},
            new() { Id = 1,  Text = "B234", Price = 3.45},
            new() { Id = 2,  Text = "X378", Price = 2.99},
            new() { Id = 3,  Text = "E333", Price = 4.23},
            new() { Id = -1, Text = "Exit" },
        };
    }
}
