using System;
using System.Collections.Generic;
using MenuVeryBasic.Models;
using Spectre.Console;

namespace MenuVeryBasic.Classes
{
    class MenuOperations
    {
        /// <summary>
        /// Create main menu
        /// The property Information is optional
        /// </summary>
        public static SelectionPrompt<MenuItem> MainSelectionPrompt()
        {
            SelectionPrompt<MenuItem> menu = new()
            {
                HighlightStyle = new Style(Color.Black, Color.White, Decoration.None)
            };

            menu.Title("[cyan]Select a option[/]");
            menu.AddChoices(new List<MenuItem>()
            {
                new () {Id = 1, Text = "Enter an animal",  Information = "Enter",  
                    Action = Option1 },
                new () {Id = 2, Text = "Have all animals speaks", Information = "Speak", 
                    Action = () =>  AnsiConsole.MarkupLine("[yellow]Call method to have animals speak[/]") },
                new () {Id = -1,Text = "Exit"},
            });

            return menu;

        }

        public static SelectionPrompt<MenuItem> AnimalSelectionPrompt()
        {
            SelectionPrompt<MenuItem> menu = new()
            {
                HighlightStyle = new Style(Color.Black, Color.White, Decoration.None)
            };

            menu.Title("[cyan]Select an animal[/]");
            menu.AddChoices(new List<MenuItem>()
            {
                new () {Id = 1, Text = "Enter an animal",
                    Action = EnterAnimal },
                new () {Id = 2, Text = "Dog selected", 
                    Action = () =>  DoSomething("dog") },
                new () {Id = 3, Text = "Cat selected",
                    Action = () =>  DoSomething("cat") },
                new () {Id = -1,Text = "Main menu"},
            });

            return menu;

        }

        public static void Option1()
        {
            
            while (true)
            {
                Console.Clear();
                var menuItem = AnsiConsole.Prompt(AnimalSelectionPrompt());
                if (menuItem.Id != -1)
                {
                    menuItem.Action();
                }
                else
                {
                    return;
                }
            }

        }

        public static void EnterAnimal()
        {
            Console.WriteLine("Enter animal code goes here");
            Console.ReadLine();
        }

        public static void DoSomething(string text)
        {
            Console.WriteLine(text);
            Console.ReadLine();
        }
    }
 
}
