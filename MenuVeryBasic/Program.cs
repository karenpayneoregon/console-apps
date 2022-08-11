using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MenuVeryBasic.Classes;
using MenuVeryBasic.Models;
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
                    Console.ReadLine();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
