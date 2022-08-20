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

        private static void Dump1()
        {
            var line =
                "2 2484,7381,3099,6847,7716,7303,1255,1098,0070 332 " +
                "1586,0764,1270,3897,9473,5890,5301,0690,6699 0142 5561," +
                "6611,5226,9148,3861,8905,9496,4827,8155";

            var result = line.RemoveFromStart("2 ");
        }
    }
}





