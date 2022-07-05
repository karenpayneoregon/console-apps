using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MenuConsoleAppBasic.Classes;
using MenuConsoleAppBasic.Models;
using Spectre.Console;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace MenuConsoleAppBasic
{
    partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample";
            W.SetConsoleWindowPosition(W.AnchorWindow.Center);

        }

        private static void Selection(MenuItem menuItem, List<Employee> EmployeesList)
        {
            switch (menuItem.Id)
            {
                case 0:
                    Operations.List(EmployeesList);
                    break;
                case 1:
                    if (AnsiConsole.Confirm("Add new manager"))
                    {
                        EmployeesList.Add(Operations.AddEmployee(JobType.Manager));
                    }
                    break;
                case 2:
                    if (AnsiConsole.Confirm("Add new engineer"))
                    {
                        EmployeesList.Add(Operations.AddEmployee(JobType.Engineer));
                    }
                    break;
                case 3:
                    if (AnsiConsole.Confirm("Add new regular employee"))
                    {
                        EmployeesList.Add(Operations.AddEmployee(/* default is Employee*/));
                    }
                    break;
                case 4:
                    var employee = AnsiConsole.Prompt(MenuOperations.RemoveMenu(EmployeesList));
                    if (employee.Id == -2)
                    {
                        break;
                    }
                    if (AnsiConsole.Confirm($"Remove {employee.FirstName} {employee.LastName}"))
                    {
                        var success = Operations.Remove(EmployeesList,employee);
                        if (success == false)
                        {
                            
                        }
                    }
                    break;
                case 5:
                    Operations.Save(EmployeesList);
                    break;
            }
        }
    }
}





