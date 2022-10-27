using GetStringApp.Classes;

namespace GetStringApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.MarkupLine("[yellow]Must enter a value[/]");
            var value = Prompts.GetString(false);
            Console.WriteLine($"{value}");

            AnsiConsole.MarkupLine("[yellow]Value is optional, press Enter to abort[/]");
            value = Prompts.GetString(true);
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Empty");
            }
            else
            {
                Console.WriteLine($"{value}");
            }

            AnsiConsole.MarkupLine("[yellow]First name (min 3 chars)[/]");
            value = Prompts.GetFirstName();
            Console.WriteLine(value);
            Console.ReadLine();
        }
    }
}