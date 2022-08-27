using System;
using System.Threading.Tasks;

namespace MarkOfTheWeb.Classes
{
    /// <summary>
    /// Provides timeout to ReadLine for Console projects
    /// </summary>
    public static class ConsoleWaiter
    {
        /// <summary>
        /// Wait for timeout or user presses a key
        /// </summary>
        /// <param name="timeout">TimeSpan</param>
        /// <returns></returns>
        public static string ReadLineWithTimeout(TimeSpan timeout)
        {
            var task = Task.Factory.StartNew(Console.ReadLine);

            var result = Task.WaitAny(new Task[] { task }, timeout) == 0
                ? task.Result
                : string.Empty;

            return result!;
        }



        /// <summary>
        /// Auto-close after five seconds
        /// </summary>
        /// <returns>string which can be used if not using for exiting</returns>
        public static string ReadLineWithTimeout()
        {
            var time = TimeSpan.FromSeconds(5);
            return ReadLineWithTimeout(time);
        }

    }
}