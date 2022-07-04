using System;
using System.Collections.Generic;
using MenuConsoleAppBasic.Models;
using Spectre.Console;

namespace MenuConsoleAppBasic.Classes
{
    public class Operations
    {

        public static Employee AddEmployee()
        {
            Employee employee = new Employee
            {
                FirstName = GetFirstName(),
                LastName = GetLastName(),
                Salary = GetSalary()
            };

            return employee;
        }

        public static string GetFirstName() =>
            AnsiConsole.Prompt(
                new TextPrompt<string>("[white]First name[/]?")
                    .PromptStyle("yellow")
                    .ValidationErrorMessage("[red]Please enter your first name[/]"));

        public static string GetLastName() =>
            AnsiConsole.Prompt(
                new TextPrompt<string>("[white]Last name[/]?")
                    .PromptStyle("yellow")
                    .ValidationErrorMessage("[red]Please enter your last name[/]"));

        public static double GetSalary() =>
            AnsiConsole.Prompt(
                new TextPrompt<double>("[white]Salary[/]?")
                    .PromptStyle("yellow")
                    .ValidationErrorMessage("[red]Please enter salary[/]"));

        public static void List(List<Employee> list)
        {
            if (list.Count == 0)
            {
                AnsiConsole.MarkupLine("Nothing is list, press [b]ENTER[/] to return to menu");
                Console.ReadLine();
                return;
            }

            var table = new Table()
                .RoundedBorder()
                .AddColumn("[b]First[/]")
                .AddColumn("[b]Last[/]")
                .AddColumn("[b]Salary[/]")
                .Alignment(Justify.Center)
                .BorderColor(Color.LightSlateGrey)
                .Title("[yellow]Employee list[/]");

            foreach (var employee in list)
            {
                table.AddRow(employee.FirstName, employee.LastName, employee.Salary.ToString("C"));
            }

            AnsiConsole.Write(table);
            AnsiConsole.MarkupLine("Press [b]ENTER[/] to return to menu");
            Console.ReadLine();
        }
    }
}
