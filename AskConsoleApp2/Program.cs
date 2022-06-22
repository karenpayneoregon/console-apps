using System;
using System.Runtime.CompilerServices;
using AskConsoleApp2.Classes;
using AskConsoleApp2.Models;

namespace AskConsoleApp2
{
    partial class Program
    {
        static void Main(string[] args)
        {
            UserChoices userChoices = Configuration.Get();
            Console.ReadLine();
        }

        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample";
        }
    }
}
