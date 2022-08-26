using System;
using System.Diagnostics;
using myage.Extensions;

// ReSharper disable once IdentifierTypo
namespace myage.Classes
{
    public class Operations
    {
        public static void RunWork(CommandLineOptions options)
        {
            var fromDateTime = options.From;
           

            if (options.To.IsMinDate())
            { 
                Console.WriteLine($"Invalid date(s): --from {options.From:d} --to {options.To:d}");
                Environment.Exit(-1);

            }

            var toDateTime = options.To;
            var age = fromDateTime.Age(toDateTime);
            Debug.WriteLine(age.YearsMonthsDays);
            Console.WriteLine($"Age is {age.YearsMonthsDays}");
        }
    }
}
