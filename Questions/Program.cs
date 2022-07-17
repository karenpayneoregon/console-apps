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
            handler = ConsoleEventCallback;
            SetConsoleCtrlHandler(handler, true);

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
}
