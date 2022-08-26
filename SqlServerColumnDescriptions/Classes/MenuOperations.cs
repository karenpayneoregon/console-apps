using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlServerColumnDescriptions.Models;

namespace SqlServerColumnDescriptions.Classes;

internal class MenuOperations
{
    public static SelectionPrompt<DatabaseName> DatabaseNamesMenu()
    {
        SelectionPrompt<DatabaseName> menu = new()
        {
            HighlightStyle = new Style(Color.Cyan1, Color.Black, Decoration.None)
        };

        menu.Title("Select a [B]database[/]");
        menu.MoreChoicesText("[grey](Move up and down to reveal more databases)[/]");
        menu.AddChoices(DataOperations.DatabaseNames());

        return menu;
    }
}