using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Spectre.Console;

namespace MenuVeryBasic
{
    partial class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                var menuItem = AnsiConsole.Prompt(SelectionPrompt());
                if (menuItem.Id != -1)
                {
                    AnsiConsole.MarkupLine($"You selected [b]{menuItem.Information}[/] press [yellow]ENTER[/] to return to the menu");
                    Console.ReadLine();
                }
                else
                {
                    return;
                }
            }
        }
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
                new MenuItem() {Id = 1, Name = "Attack", Information = "First"},
                new MenuItem() {Id = 2, Name = "Item",   Information = "Second"},
                new MenuItem() {Id = 3, Name = "Run",    Information = "Third"},
                new MenuItem() {Id = -1,Name = "Exit"},
            });

            return menu;

        }


    }

    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public override string ToString() => Name;
    }
}
