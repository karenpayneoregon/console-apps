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

                var menuItem = AnsiConsole.Prompt(MenuOperations.SelectionPrompt());
                if (menuItem.Id != -1)
                {
                    menuItem.Action();
                    Console.ReadLine(); // here got demoing only
                    Console.ReadLine(); // here got demoing only
                }
                else
                {
                    return;
                }
            }
        }
    }
}
