using System;
using AskConsoleApp3.Classes;
using AskConsoleApp3.Models;
using Spectre.Console;

namespace AskConsoleApp3
{
    partial class Program
    {

        static void Main(string[] args)
        {

            if (AnsiConsole.Confirm("[lime]Would you like to buy a Ticket?[/]"))
            {

                AnsiConsole.Clear();

                var route = RouteChoices;

                AnsiConsole.Clear();

                switch (route.Id)
                {
                    case 1:
                        AnsiConsole.MarkupLine("[b]First[/] selected");
                        break;
                    case 2:
                        AnsiConsole.MarkupLine("[b]Second[/] selected");
                        break;
                    case 3:
                        AnsiConsole.MarkupLine("[b]Canceled[/]");
                        break;
                }

                var rule = new Rule("Press [b]any key[/] to continue")
                {
                    Alignment = Justify.Left
                };
                AnsiConsole.Write(rule);

                Console.ReadLine();

            }
            else
            {
                AnsiConsole.MarkupLine("[b]No[/] Ticket Purchased: [cyan]Have a great day![/]");
                Console.ReadLine();
            }
        }


        public static Route RouteChoices =>
            AnsiConsole.Prompt(
                new SelectionPrompt<Route>()
                    .Title("[cyan]Select a route or last item to cancel by using up/down arrows then press enter[/]")
                    .AddChoices(MenuChoices.Routes)
                    .HighlightStyle(
                        new Style(
                            Color.White, 
                            Color.Black, 
                            Decoration.Invert)));
    }
}
