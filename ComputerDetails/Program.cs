#nullable disable
using ComputerDetails.Classes;


namespace ComputerDetails;

internal partial class Program
{
    static void Main(string[] args)
    {
        CommandLineHelp.ParseArguments(args);
    }
}