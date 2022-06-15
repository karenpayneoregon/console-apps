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
                    new () { Id = 1, List = new List<string>() { "C# [b]✓[/]", "F#", "Type script", "VB.NET" } },
                    new () { Id = 2, List = new List<string>() { "[green1][b]Visual Studio[/][/] [b]✓[/]", "[pink3][b]Visual Studio Code[/][/]", "[lightsteelblue][b]Visual Studio Code web[/][/]", "[dodgerblue2][b]NotePad ++[/][/]", "[green1][b]Rider[/][/] [b]✓[/]" } },
                    new () {Id = 3, List = new List<string>(){ "StackOverflow", "Microsoft Q&A" } }
                };

        }
}
