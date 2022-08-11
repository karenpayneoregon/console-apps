using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuVeryBasic.Models;
using Spectre.Console;

namespace MenuVeryBasic.Classes
{
    class MenuOperations
    {
        /// <summary>
        /// Create main menu
        /// </summary>
        public static SelectionPrompt<MenuItem> SelectionPrompt()
        {
            SelectionPrompt<MenuItem> menu = new()
            {
                HighlightStyle = new Style(Color.Black, Color.White, Decoration.None)
            };

            menu.Title("[black on yellow]Select a option[/]");
            menu.PageSize = 14;
            menu.AddChoices(new List<MenuItem>()
            {
                new () {Id = 1, Text = "Add item",  Information = "First",  Action = () => AnsiConsole.MarkupLine("[yellow]Add[/]") },
                new () {Id = 2, Text = "Edit item", Information = "Second", Action = () =>  AnsiConsole.MarkupLine("[red]Edit[/]") },
                new () {Id = 3, Text = "View all",  Information = "Third",  Action = () =>  AnsiConsole.MarkupLine("[cyan]View[/]") },
                new () {Id = -1,Text = "Exit"},
            });

            return menu;

        }
    }
}
