using Holidays.Classes;

namespace Holidays
{
    internal partial class Program
    {
        static async Task Main(string[] args)
        {

            try
            {
                await Operations.Run("US");
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