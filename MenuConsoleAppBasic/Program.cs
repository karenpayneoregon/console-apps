using System;
using System.Collections.Generic;
using MenuConsoleAppBasic.Classes;
using MenuConsoleAppBasic.Models;
using Spectre.Console;
using static ConsoleHelperLibrary.Classes.KeysHelper;

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
                AnsiConsole.Write(
                    new Panel(new Text("Some fictitious company HR").Centered())
                        .Expand()
                        .SquareBorder()
                        .BorderStyle(new Style(Color.Cornsilk1))
                        .Header("[LightGreen]About[/]")
                        .HeaderAlignment(Justify.Center));
                menuItem = AnsiConsole.Prompt(MenuOperations.MainMenu());
                Selection(menuItem, EmployeesList);
            }

        }
    }
}
