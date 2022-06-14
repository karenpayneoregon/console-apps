using System;
using MenuConsoleApp.Classes;
using Spectre.Console;

namespace MenuConsoleApp
{
    partial class Program
    {

        static void Main(string[] args)
        {
            //var categorySelection = MenuOperations.ConfigureCategorySelectionPrompt();
            var productContinue = true;

            while (true)
            {

                var categories = AnsiConsole.Prompt(MenuOperations.CategoryMenu());

                if (categories.CategoryId != -1)
                {
                    Console.Clear();

                    var products = DataOperations.ProductListFromJson(categories.CategoryId);

                    if (products.Count > 0)
                    {
                        productContinue = true;
                        MenuOperations.ProductMenu(productContinue, categories);
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
