﻿using System;
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
        /// <summary>
        /// Location for reading and saving employees to and from
        /// </summary>
        private static string _fileName => Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Employees.json");

        /// <summary>
        /// Add new employee
        /// </summary>
        /// <param name="jobType"><see cref="JobType"/></param>
        /// <returns>new employee</returns>
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

        #region Methods to obtain user input

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

        #endregion

        /// <summary>
        /// Present list of employees in a table/grid
        /// </summary>
        /// <param name="list"></param>
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

                if (employee.FirstName == "Return")
                {
                    continue;
                }
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

        /// <summary>
        /// Remove an employee from a given list
        /// </summary>
        /// <param name="list">List to remove employee from</param>
        /// <param name="employee">Employee to remove from list</param>
        /// <returns>success</returns>
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

            var lastId = list.LastOrDefault(emp => emp.Id > -1)!.Id +1;

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
            => JsonSerializer.Deserialize<List<Employee>>(File.ReadAllText(_fileName))!;
    }
}
