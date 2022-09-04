using GenerateAppSettingsSqlServer.Models;

namespace GenerateAppSettingsSqlServer.Classes;

class MenuOperations
{
    /// <summary>
    /// Create main menu
    /// </summary>
    public static SelectionPrompt<MenuItem> SelectionPrompt(List<string> names)
    {
        SelectionPrompt<MenuItem> menu = new()
        {
            HighlightStyle = new Style(Color.Black, Color.White, Decoration.None)
        };

        menu.Title("[black on yellow]Select a database[/]");
        menu.PageSize = 14;

        for (int index = 0; index < names.Count; index++)
        {
            menu.AddChoice(new MenuItem() { Id = index + 1, Text = names[index] });
        }

        menu.AddChoice(new MenuItem() { Id = -1, Text = "Exit" });
        return menu;

    }
}