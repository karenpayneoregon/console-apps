using NorthWind2020ConsoleApp.Classes;


namespace NorthWind2020ConsoleApp;

partial class Program
{
    static void Main(string[] args)
    {
        EmployeeOperations.EmployeeReportsToManager();
        //Colored.ShowMessage("Press any key to continue");
        Console.ReadLine();
    }
}