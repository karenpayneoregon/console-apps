using System;
using System.Collections.Generic;

namespace GetIntConsoleApp1
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            // ask for max count, here we default to 5
            int count = GetNumber("Enter count",5);
            List<int> list = new List<int>();

            // loop through to get entries until we hit the max
            while (list.Count < count)
            {
                Console.Clear();
                Console.WriteLine(string.Join(",", list));
                list.Add(GetNumber("Enter ID",0));
            }

            // display results
            Console.Clear();
            Console.WriteLine(string.Join(",", list));
            Console.ReadLine();
        }

        /// <summary>
        /// Prompt for int
        /// </summary>
        /// <param name="prompt">Text to display</param>
        /// <param name="defaultValue">Default value is used if enter if pressed</param>
        /// <returns>int</returns>
        /// <remarks>
        /// Advance use can have validation, omitted here
        /// </remarks>
        internal static int GetNumber(string prompt, int defaultValue)
        {
            return AnsiConsole.Prompt(
                new TextPrompt<int>($"[white]{prompt}[/]")
                    .PromptStyle("white")
                    .DefaultValueStyle(new Style(Color.Yellow))
                    .DefaultValue(defaultValue)
                    .ValidationErrorMessage("[white on red]Invalid entry![/]"));
        }
    }
}