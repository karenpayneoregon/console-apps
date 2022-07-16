using System;
using System.Runtime.CompilerServices;

using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace Questions
{
    partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample";
            W.SetConsoleWindowPosition(W.AnchorWindow.Center);
        }

        /// <summary>
        /// Random double truncated to two decimal places
        /// </summary>
        /// <param name="minimum">min value</param>
        /// <param name="maximum">max value</param>
        /// <returns>double</returns>
        public static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();

            var result = random.NextDouble() * (maximum - minimum) + minimum;
            return Math.Truncate(100 * result) / 100;
        }
    }
}





