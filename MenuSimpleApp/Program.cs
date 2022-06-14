using System;
using System.Linq;
using MenuSimpleApp.Classes;
using Spectre.Console;
using static MenuSimpleApp.Classes.ConsoleHelpers;

namespace MenuSimpleApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var menuSelections = MockOperations.GetMenuItems();

            while (true)
            {
                Console.Clear();
                
                var menuItem = AnsiConsole.Prompt(MenuOperations.SelectionPrompt());

                if (menuItem.Id == -1)
                {
                    
                    AnsiConsole.Write(new FigletText("Bye").LeftAligned().Color(Color.Red));
                    ReadLineAsStringTimeout();
                    return;

                }
                else
                {
                    var month = menuSelections.FirstOrDefault(item => item.Id == menuItem.Id);

                    AnsiConsole.Write(
                        new Markup($"[bold yellow]{month.Name}[/] [bold cyan]{month.Information}![/]"));

                    ReadLineAsStringTimeout(new TimeSpan(0,0,0,10));
                }
            }
            
        }
    }
}
