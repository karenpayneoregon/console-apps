using System;
using System.Threading;
using Spectre.Console;
using StackProgressConsoleApp.Classes;

namespace StackProgressConsoleApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            ExecuteProgress();
            Console.ReadLine();
        }

        private static void ExecuteProgress()
        {
            Console.Write("Performing some task... ");
            using var progress = new ProgressBar();
            for (int index = 0; index <= 100; index++)
            {
                progress.Report((double)index / 100);
                // do work here or call a method to perform work
                Thread.Sleep(20);
            }
        }
    }
}
