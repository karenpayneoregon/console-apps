using System;
using System.Collections.Generic;
using MenuConsoleAppBasic.Classes;
using MenuConsoleAppBasic.Models;
using Spectre.Console;

namespace MenuConsoleAppBasic
{
    partial class Program
    {
        static void Main(string[] args)
        {
            MenuItem menuItem = new MenuItem();

            List<Employee> EmployeesList = Operations.ReadEmployees();

            while (menuItem.Id > -1)
            {
                AnsiConsole.Clear();
                menuItem = AnsiConsole.Prompt(MenuOperations.MainMenu());
                Selection(menuItem, EmployeesList);
            }
        }
    }
}
