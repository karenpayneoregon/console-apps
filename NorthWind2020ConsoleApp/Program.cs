using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using NorthWind2020ConsoleApp.Classes;


namespace NorthWind2020ConsoleApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            EmployeeOperations.EmployeeReportsToManager();
            Colored.ShowMessage("Press any key to continue");
            Console.ReadLine();
        }
    }
}
