using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Questions
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //handler = ConsoleEventCallback;
            //SetConsoleCtrlHandler(handler, true);

            var line = 
                "2 2484,7381,3099,6847,7716,7303,1255,1098,0070 332 " + 
                "1586,0764,1270,3897,9473,5890,5301,0690,6699 0142 5561," + 
                "6611,5226,9148,3861,8905,9496,4827,8155";

            var result = line.RemoveFromStart("2 ");


            Console.ReadLine();
        }

        static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2)
            {
                Console.WriteLine("Console window closing, death imminent");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(eventType);
                Console.ReadLine();
            }

            return false;
        }

        static ConsoleEventDelegate handler;   // Keeps it from getting garbage collected
        private delegate bool ConsoleEventDelegate(int eventType);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleCtrlHandler(ConsoleEventDelegate callback, bool add);
    }

    public static class StringExtensions
    {
        /// <summary>
        /// Trim from start a given string
        /// </summary>
        /// <param name="target">String to work on</param>
        /// <param name="trimString">String to remove from start of <see cref="target"/></param>
        /// <returns>Original string if not starting with <see cref="trimString"/> or <see cref="target"/> minus<see cref="trimString"/></returns>
        public static string RemoveFromStart(this string target, string trimString)
        {
            if (string.IsNullOrWhiteSpace(trimString)) return target;

            string result = target;
            while (result.StartsWith(trimString))
            {
                result = result[trimString.Length..];
            }

            return result;
        }
    }
}
