using System;
using System.Collections.Generic;
using System.Linq;
using NorthWind2020ConsoleApp.Data;
using NorthWind2020ConsoleApp.Models;
using NorthWind2020Library.Models;

namespace NorthWind2020Library.Classes
{
    public class EmployeeOperations
    {
        /// <summary>
        /// Example for self-referencing table where the property <see cref="Employees.ReportsTo"/> is null
        /// this indicates the <see cref="Employees"/> is a manager.
        ///
        /// <see cref="Employees.WorkersNavigation"/> for a manager will contain their employees.
        /// </summary>
        public static void EmployeeReportsTo()
        {
            using var context = new Context();

            List<Employees> allEmployeesList = context.Employees.ToList();

            List<Employees> managers = allEmployeesList
                .Where(employee => !employee.ReportsTo.HasValue)
                .ToList();

            Console.WriteLine("Managers/workers");
            foreach (Employees manager in managers)
            {
                Console.WriteLine($"{manager.FullName} - {manager.WorkersNavigation.Count}");
            }

            Console.WriteLine();

            Console.WriteLine("Workers");
            var workers = allEmployeesList.Where(x => x.ReportsTo.HasValue).ToList();

            foreach (var worker in workers)
            {
                Console.WriteLine($"{worker.FullName} {worker.ReportsToNavigation.FullName}");
            }

        }

    }
}
