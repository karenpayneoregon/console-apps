using Holidays.Classes;

namespace Holidays
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {

            try
            {
                await Operations.Run();
            }
            catch (Exception localException)
            {
                AnsiConsole.Clear();
                ExceptionHelpers.ColorWithCyanFuchsia(localException);
            }

            Console.ReadLine();
        }
    }
}