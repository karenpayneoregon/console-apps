using System.Collections.Generic;
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

            menu.Title("[cyan]Select a option[/]");
            menu.AddChoices(new List<MenuItem>()
            {
                new () {Id = 1, Text = "Play the game",  Information = "Game",  
                    Action = () =>  AnsiConsole.MarkupLine("[yellow]Simulate game[/]") },
                new () {Id = 2, Text = "View rules", Information = "Manual", 
                    Action = () =>  AnsiConsole.MarkupLine("[yellow]View rules[/]") },
                new () {Id = -1,Text = "Exit"},
            });

            return menu;

        }
    }
}
