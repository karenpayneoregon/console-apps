using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Spectre.Console;
using TreeConsoleApp.Classes;
using TreeConsoleApp.Models;

namespace TreeConsoleApp
{

    public partial class Program
    {
        static void Main(string[] args)
        {
            List<Item> itemList = Mocked.ItemList();
            var root = new Tree("[darkseagreen2_1]Root[/]");

            foreach (var category in Mocked.Categories)
            {
                var currentNode = root.AddNode(category.Text);

                itemList.Where(item => item.Id == category.Id).ToList()
                    .ForEach(item => item.List
                        .ForEach(value => currentNode.AddNode(value)));
            }

            AnsiConsole.Write(root);

            Console.ReadLine();
        }
    }
}
