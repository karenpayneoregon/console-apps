using System;
using MenuConsoleApp.Classes;
using MenuConsoleApp.Models;
using Spectre.Console;

namespace MenuConsoleApp
{
    partial class Program
    {

        static void Main(string[] args)
        {
            
            Categories categories = new();
            while (categories.CategoryId > -1)
            {

                categories = AnsiConsole.Prompt(MenuOperations.CategoryMenu());

                if (categories.CategoryId != -1)
                {
                    Console.Clear();

                    var products = DataOperations.ProductListFromJson(categories.CategoryId);

                    if (products.Count > 0)
                    {

                        /*
                         * returns selected product or exit with no selection with id of -1
                         */
                        var product = MenuOperations.ProductMenu(categories);
                    }
                    else
                    {
                        AnsiConsole.MarkupLine($"No products for [b]{categories.CategoryName}[/]");
                    }

                    Console.Clear();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
