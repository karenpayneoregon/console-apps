using System;
using System.Threading.Tasks;
using static System.Console;

namespace LoginConsoleApp.Classes
{
    public static class ConsoleHelpers
    {
        public static double DefaultTimeOut { get; set; } = 2;
        /// <summary>
        /// Wait a specific amount of time for Console.ReadLine. Must press ENTER to collect input or no key to timeout
        /// </summary>
        /// <param name="timeout">Valid time span or if not passed default to <see cref="DefaultTimeOut"/> in seconds</param>
        /// <returns>Input from ReadLine or an empty string</returns>
        public static string ReadLineAsStringTimeout(TimeSpan? timeout = null)
        {
            var timeSpan = timeout ?? TimeSpan.FromSeconds(DefaultTimeOut);
            var task = Task.Factory.StartNew(ReadLine);
            var value = (Task.WaitAny(new Task[] { task }, timeSpan) == 0) ? task.Result : string.Empty;

            return value;

        }
    }
}
