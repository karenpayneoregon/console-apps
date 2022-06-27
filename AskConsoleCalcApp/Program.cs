using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AskConsoleCalcApp.Classes;
using Spectre.Console;

namespace AskConsoleCalcApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //CalculateItem calculateItem = new()
            //{
            //    FirstValue = Prompts.GetInt("First value"),
            //    SecondValue = Prompts.GetInt("Second value"),
            //    Operator = Prompts.GetOperator()
            //};

            //Console.WriteLine(calculateItem);

            //_ = AnsiConsole.Decoration = Decoration.Bold;
            //if (Prompts.AskConfirmation())
            //{
            //    Console.WriteLine("Y");
            //}
            //else
            //{
            //    Console.WriteLine("N");
            //}

            Console.WriteLine(Prompts.AskConfirmation("Continue"));
            
            Console.ReadLine();
        }

        private static void PerformCalculations(CalculateItem calculateItem)
        {
            Console.WriteLine($"Ready with: {calculateItem}");
        }
        
        public class CalculateItem
        {
            public int? FirstValue { get; set; }
            public int? SecondValue { get; set; }
            public string Operator { get; set; }
            public override string ToString() => $"{FirstValue} {Operator} {SecondValue}";
        }
    }


}
