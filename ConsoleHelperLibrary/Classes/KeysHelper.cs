using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHelperLibrary.Classes
{
    public static class KeysHelper
    {
        /// <summary>
        /// Provides a prompt and timeout so no interaction is required.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="timeout">seconds to wait or if not passed defaults to five second wait</param>
        /// <returns>user input or an empty string</returns>
        public static string ReadLineTimed(string message, TimeSpan? timeout = null)
        {
            static void WriteSectionBold(string message)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(message);
                Console.ResetColor();
            }

            WriteSectionBold(message);

            var task = Task.Factory.StartNew(Console.ReadLine);
            var result = 
                (
                    Task.WaitAny(new Task[] { task }, timeout ?? TimeSpan.FromSeconds(5)) == 0) ? 
                    task.Result : 
                    string.Empty;

            return result;
        }
    }
}
