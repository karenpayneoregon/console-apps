using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using MenuConsoleAppBasic.Models;
using Spectre.Console;

namespace MenuConsoleAppBasic.Classes
{
    public class Operations
    {
        private static string _fileName => Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Employees.json");

        public static Employee AddEmployee(JobType jobType = JobType.Employee)
        {
            
            var rule = new Rule($"[cyan]Add new[/] [b]{jobType}[/]")
            {
                Alignment = Justify.Left
            };

            AnsiConsole.Write(rule);
            AnsiConsole.WriteLine();

            Employee employee = new Employee
            {
                Id = -1,
                FirstName = GetFirstName(),
                LastName = GetLastName(),
                Salary = GetSalary(),
                JobType = jobType

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
                    .ValidationErrorMessage("[red]Please enter salary (numbers only)[/]"));

        public static void List(List<Employee> list)
        {
            if (list.Count == 0)
            {
                AnsiConsole.MarkupLine("[yellow]Nothing is list[/], press [b]ENTER[/] to return to menu");
                Console.ReadLine();
                return;
            }

            var table = new Table()
                .RoundedBorder()
                .AddColumn("[b]First[/]")
                .AddColumn("[b]Last[/]")
                .AddColumn("[b]Salary[/]")
                .AddColumn("[b]Type[/]")
                .Alignment(Justify.Center)
                .BorderColor(Color.LightSlateGrey)
                .Title("[LightGreen]Employee list[/]");

            foreach (var employee in list)
            {
                
                table.AddRow(
                    employee.FirstName, 
                    employee.LastName, 
                    employee.Salary.ToString("C"), 
                    employee.JobType.ToString());

            }

            AnsiConsole.Write(table);
            AnsiConsole.MarkupLine("Press [b]ENTER[/] to return to menu");
            Console.ReadLine();
        }

        public static bool Remove(List<Employee> list,Employee employee)
        {
            var item = list.FirstOrDefault(emp => emp.Id == employee.Id);
            if (item is not null)
            {
                list.Remove(employee);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Assumes there is at least one Employee
        /// </summary>
        public static void Save(List<Employee> list)
        {
            if (list.Count == 0)
            {
                return;
            }

            var lastId = list.LastOrDefault(emp => emp.Id > -1).Id +1;

            for (int index = 0; index < list.Count; index++)
            {
                if (list[index].Id == -1)
                {
                    list[index].Id = lastId;
                    lastId++;
                }
            }

            var json = JsonSerializer.Serialize(list, new JsonSerializerOptions()
            {
                WriteIndented = true
            });

            File.WriteAllText(_fileName, json);

        }
        public static List<Employee> ReadEmployees()
            => JsonSerializer.Deserialize<List<Employee>>(File.ReadAllText(_fileName));
    }
}
