using System.Collections.Generic;
using TreeConsoleApp.Models;

namespace TreeConsoleApp.Classes
{
        public class Mocked
        {
            public static List<Category> Categories =>
                new()
                {
                    new () { Id = 1, Text = "[yellow]Programming languages[/]" },
                    new () { Id = 2, Text = "[white]Code with[/]" },
                    new () { Id = 3, Text = "[cyan]Where to ask question[/]" },
                };
            public static List<Item> ItemList()
                => new()
                {
                    new () { Id = 1, List = new List<string>() { "C#", "F#", "Type script", "VB.NET" } },
                    new () { Id = 2, List = new List<string>() { "Visual Studio", "Visual Studio Code", "Visual Studio Code web", "Notepad ++" } },
                    new () {Id = 3, List = new List<string>(){ "StackOverflow", "Microsoft Q&A" } }
                };

        }
}
