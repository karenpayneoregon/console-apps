namespace MenuFuelApp;

internal partial class Program
{
    static void Main()
    {
        AnsiConsole.Record();
        MenuItem selection = new();
        while (selection.Id > -1)
        {
            Console.Clear();
            // display menu, get selection
            selection = AnsiConsole.Prompt(MenuOperations.MainMenu());

            // -1 is exiting selection
            if (selection.Id != -1)
            {
                DisplayFuelType(selection);
            }
            else
            {
                var txt = AnsiConsole.ExportText();
                if (string.IsNullOrWhiteSpace(txt))
                {
                    // user exited without selection
                }
                else
                {
                    /*
                     * at least one selection was made
                     * can log it to say a text file
                     */
                }
                return;
            }
        }

    }

    private static void DisplayFuelType(MenuItem menuItem)
    {
        Console.Clear();
        AnsiConsole.MarkupLine(menuItem.Id > -1
            ? $"Fuel type [cyan]{menuItem.Text}[/] at " +
              $"[cyan]{menuItem.Price:C}[/] Press a key for menu"
            : "[yellow]Nothing selected[/] Press a key for menu");
        Console.ReadLine();
    }
}
// move to a separate file
public class MenuItem
{
    public int Id { get; set; }
    public string Text { get; set; }
    public double Price { get; set; }
    // what to display in menu
    public override string ToString() => Text;
}

// move to a separate file
class MenuOperations
{
    
    // Create menu with mocked items
    public static SelectionPrompt<MenuItem> MainMenu()
    {
        // style of menu
        SelectionPrompt<MenuItem> menu = new()
        {
            HighlightStyle = new Style(Color.White, Color.Blue, Decoration.None)
        };

        menu.Title("[white on blue]Select fuel type[/]");
        menu.AddChoices(MenuItems());

        return menu;
    }
    // For a real app, load items from a file or database
    public static List<MenuItem> MenuItems() =>
    [
        new() { Id = 0, Text = "Diesel", Price = 3.99 },
        new() { Id = 1, Text = "Gasoline", Price = 3.45 },
        new() { Id = 2, Text = "Ethanol", Price = 2.99 },
        new() { Id = -1, Text = "Exit" }
    ];
}
