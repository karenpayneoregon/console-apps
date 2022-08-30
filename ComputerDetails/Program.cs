#nullable disable
using ComputerDetails.Classes;
using ComputerDetails.Models;


namespace ComputerDetails
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            CommandLineHelp.ParseArguments(args);
            Console.ReadLine(); // for testing
            
        }
    }
}