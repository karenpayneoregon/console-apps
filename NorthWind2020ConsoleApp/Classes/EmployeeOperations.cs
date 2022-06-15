﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind2020ConsoleApp.Data;
using NorthWind2020ConsoleApp.Models;
using Spectre.Console;

namespace NorthWind2020ConsoleApp.Classes
{
    public class EmployeeOperations
    {

        /// <summary>
        /// Example for self-referencing table where the property <see cref="Employees.ReportsTo"/> is null
        /// this indicates the <see cref="Employees"/> is a manager.
        ///
        /// <see cref="Employees.WorkersNavigation"/> for a manager will contain their employees.
        /// </summary>
        [SuppressMessage("ReSharper", "All")]
        public static void EmployeeReportsToManager()
        {
            using var context = new Context();

            List<Employees> employees = context.Employees.ToList();
            
            List<IGrouping<int?, Employees>> groupedData = employees
                .Where(employee => employee.ReportsTo.HasValue)
                .ToList()
                .OrderBy(employee => employee.LastName)
                .GroupBy(employee => employee.ReportsTo)
                .ToList();

            var table = CreateViewTable();

            List<Manager> managers = new();

            foreach (var group in groupedData)
            {

                Manager manager = new()
                {
                    Employee = employees.Find(employee => employee.EmployeeId == group.Key.Value)
                };

                foreach (Employees groupedItem in group)
                {
                    manager.Workers.Add(groupedItem);
                }

                managers.Add(manager);

            }

            managers = managers.OrderBy(employee => employee.Employee.LastName).ToList();

            foreach (var manager in managers)
            {
                table.AddRow(manager.Employee.FullName);
                foreach (var worker in manager.Workers)
                {
                    table.AddRow("", worker.FullName);
                }
            }

            Console.Clear();
            AnsiConsole.Write(table);

        }

        private static Table CreateViewTable() =>
            new Table()
                .Border(TableBorder.Square)
                .BorderColor(Color.Grey100)
                .Alignment(Justify.Center)
                .Title("~[white on blue][B]Employees[/][/]~")
                .AddColumn(new TableColumn("[u]Manager[/]"))
                .AddColumn(new TableColumn("[u]Workers[/]"));
    }
}
