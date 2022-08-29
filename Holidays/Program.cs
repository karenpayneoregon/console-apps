using System.Text.Json;
using Holidays.Classes;
using Nager.Date;

namespace Holidays
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {
            AnsiConsole.MarkupLine("[yellow]Getting holidays[/]");

            try
            {
                await Operations.Run();
            }
            catch (Exception localException)
            {
                AnsiConsole.Clear();
                ExceptionHelpers.ColorWithCyanFuchsia(localException);
            }

            AnsiConsole.MarkupLine("[yellow]Exit[/]");
            Console.ReadLine();
        }
    }
}