using System;
using Spectre.Console;

namespace WelcomeApp
{
    partial class Program
    {
        static void Main(string[] args)
        {

            AnsiConsole.Write(
                new FigletText("Do whatever")
                    .Centered()
                    .Color(Color.DeepPink1));

            Console.ReadLine();
        }
    }
}
