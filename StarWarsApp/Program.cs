using System;
using Spectre.Console;

namespace StarWarsApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.CursorTop = 10;

            string[] words = { "May", "the", "Force", "be", "with", "you" };

            var font = FigletFont.Load("starwars.flf");

            foreach (var word in words)
            {
                AnsiConsole.Write(
                    new FigletText(font, word)
                        .Centered()
                        .Color(Color.Chartreuse3));

            }

            Console.ReadLine();

        }
    }
}
