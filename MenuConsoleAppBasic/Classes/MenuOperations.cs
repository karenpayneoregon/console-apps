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
        private static Style _highLightStyle => new(
            Color.LightGreen,
            Color.Black,
            Decoration.None);

        public static SelectionPrompt<MenuItem> MainMenu()
        {

            SelectionPrompt<MenuItem> menu = new()
            {
                HighlightStyle = _highLightStyle
            };

            menu.Title("Select an [B]option[/]");
            menu.AddChoices(new List<MenuItem>()
            {
                new() {Id = 0,  Text = "List employees"},
                new() {Id = 1,  Text = "Add manager"},
                new() {Id = 2,  Text = "Add engineer"},
                new() {Id = 3,  Text = "Add employee"},
                new() {Id = 4,  Text = "Delete an employee "},
                new() {Id = 5,  Text = "Save all"},
                new() {Id = -1, Text = "Exit"},
            });

            return menu;
        }

        public static SelectionPrompt<Employee> RemoveMenu(List<Employee> list)
        {

            list.Add(new Employee() {FirstName = "Return", LastName = "to menu", Id = -2});

            SelectionPrompt<Employee> menu = new()
            {
                HighlightStyle = _highLightStyle
            };

            menu.Title("Select an employee to [B]remove[/] or select [B]return to menu[/] to abort.");
            menu.AddChoices(list);

            return menu;
        }
    }
}
