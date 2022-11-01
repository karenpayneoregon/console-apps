using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Bogus;

namespace HoursWorkedConsoleApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        List<Employee> list = BogusOperations.Employees(3);


        foreach (var employee in list)
        {
            Console.WriteLine($"{employee.Id,-5}{employee.StartTime,-15}{employee.EndTime}");
        }

        //List<Employee> list = new List<Employee>
        //{
        //    new()
        //    {
        //        EmployeeName = "Jim",
        //        StartTime = new TimeOnly(13, 30),
        //        EndTime = new TimeOnly(14, 30)
        //    },
        //    new()
        //    {
        //        EmployeeName = "Mary",
        //        StartTime = new TimeOnly(8, 0),
        //        EndTime = new TimeOnly(10, 0)
        //    }
        //};

        TimeSpan totalSpan = new TimeSpan(list.Sum(e => e.HoursWorked().Ticks));
        Console.WriteLine($"{totalSpan:%h} hours {totalSpan:%m} minutes");

        Console.ReadLine();
    }
}

public class Employee
{
    public int Id { get; set; }
    public string EmployeeName { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public TimeSpan HoursWorked() => EndTime - StartTime;

    public Employee() { }
}

public class BogusOperations
{
    public static List<Employee> Employees(int count = 10)
    {
        return new Faker<Employee>()
            .ForRecord().RuleFor(p => p.Id, f => f.IndexVariable++)
            .RuleFor(e => e.EmployeeName, f => f.Person.FullName)
            .RuleFor(e => e.StartTime, f => f.Date.BetweenTimeOnly(new TimeOnly(8,0), new TimeOnly(10, 0)))
            .RuleFor(e => e.EndTime, f =>
                f.Date.BetweenTimeOnly(new TimeOnly(13, 0), new TimeOnly(18, 0))).Generate(count); ;


    }
}

public static class BogusExtensions
{
    public static Faker<T> ForRecord<T>(this Faker<T> faker) where T : class
    {
        faker.CustomInstantiator( _ => FormatterServices.GetUninitializedObject(typeof(T)) as T);
        return faker;
    }
}

