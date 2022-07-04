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

            List<Employee> EmployeesList = new List<Employee>();

            while (menuItem.Id > -1)
            {

                AnsiConsole.Clear();
                menuItem = AnsiConsole.Prompt(MenuOperations.MainMenu());
                switch (menuItem.Id)
                {
                    case 0:
                        Operations.List(EmployeesList);
                        break;
                    case 1:
                        Console.WriteLine("Add manager");
                        EmployeesList.Add(Operations.AddEmployee());
                        break;
                    case 2:
                        Console.WriteLine("Add Engineer");
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Delete");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
