
using PasswordGeneratorApp.Classes;

namespace PasswordGeneratorApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {

            AnsiConsole.MarkupLine("[b]Create a random password[/]");

            CommandLineHelp.ParseArguments(args);


            Console.ReadLine();
        }
    }
}