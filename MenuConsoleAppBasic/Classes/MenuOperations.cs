using System;
using System.Collections.Generic;
using Spectre.Console;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuConsoleAppBasic.Models;

namespace MenuConsoleAppBasic.Classes
{
    public class MenuOperations
    {
        public static SelectionPrompt<MenuItem> MainMenu()
        {
            SelectionPrompt<MenuItem> menu = new()
            {
                HighlightStyle = new Style(
                    Color.DodgerBlue1, 
                    Color.Black, 
                    Decoration.None)
            };

            menu.Title("Select an [B]options[/]");
            menu.AddChoices(new List<MenuItem>()
            {
                new MenuItem() {Id = 0, Text = "List employees"},
                new MenuItem() {Id = 1, Text = "Add manager"},
                new MenuItem() {Id = 2, Text = "Add Engineer"},
                new MenuItem() {Id = 3, Text = "Delete"},
                new MenuItem() {Id = -1, Text = "Exit"},
            });

            return menu;
        }
    }
}
