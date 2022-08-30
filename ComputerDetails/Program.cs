#nullable disable
using ComputerDetails.Classes;
using ComputerDetails.Models;
using System.Net.NetworkInformation;

namespace ComputerDetails
{
    internal partial class Program
    {
        static void Main(string[] args)
        {

            if (Environment.GetEnvironmentVariables().Contains("HOMESHARE"))
            {
                var home = Environment.GetEnvironmentVariable("HOMESHARE");
                Console.WriteLine(Directory.Exists(home));
            }
            //CommandLineHelp.ParseArguments(args);
            Console.ReadLine(); // for testing
            
        }


    }
}