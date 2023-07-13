using System;
using MenuVeryBasic.Classes;
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

                var menuItem = AnsiConsole.Prompt(MenuOperations.MainSelectionPrompt());
                if (menuItem.Id != -1)
                {
                    menuItem.Action();
                    //Console.WriteLine(menuItem.Information);
                    //Console.ReadLine(); 
                }
                else
                {
                    return;
                }
            }
        }
    }
}
