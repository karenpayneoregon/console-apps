using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningConsoleApp.DataClasses;
using Spectre.Console;
using UtilityLibrary.LanguageExtensions;

namespace LearningConsoleApp.Classes
{
    class LearningStrings
    {
        /// <summary>
        /// Experimenting with iterating an array with
        ///   - for statement
        ///   - reverse for statement
        ///   - Anonymous lambda statement
        ///   - foreach statement
        ///
        /// Using Spectre.Console to separate each operation
        /// Use nameof operator to indicate the method running
        /// 
        /// </summary>
        public static void IterateArray()
        {
            AnsiConsole.MarkupLine($"[b]Running[/] [chartreuse2_1]{nameof(IterateArray).SplitCamelCase()}[/]");
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[chartreuse2_1]for statement forward[/]");

            string[] monthNames = Mocked.MonthNames;

            for (int index = 0; index < monthNames.Length; index++)
            {
                Console.WriteLine($"{index +1, -3}{monthNames[index]}");
            }

            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[chartreuse2_1]foreach statement forward[/]");

            foreach (var name in monthNames)
            {
                Console.WriteLine(name);
            }

            AnsiConsole.WriteLine();

            AnsiConsole.MarkupLine("[chartreuse2_1]Anonymous foreach forward[/]");
            monthNames
                .Select((name, index) => new
                {
                    Name = name, 
                    Index = index +1
                })
                .ToList()
                .ForEach(anonymous => Console.WriteLine($"{anonymous.Index, -3}{anonymous.Name}"));

            AnsiConsole.WriteLine();

            AnsiConsole.MarkupLine("[chartreuse2_1]for statement in reverse[/]");
            for (int index = monthNames.Length - 1; index >= 0; index--)
            {
                Console.WriteLine($"{index +1, -3}{monthNames[index]}");
            }

            AnsiConsole.MarkupLine("[chartreuse2_1]end of method[/]");
        }

        /// <summary>
        /// Learning how string case sensitivity works
        /// </summary>
        public static void ArrayContains()
        {
            AnsiConsole.MarkupLine($"[b]Running[/] [chartreuse2_1]{nameof(ArrayContains).SplitCamelCase()}[/]");
            AnsiConsole.WriteLine();
            
            string[] monthNames = Mocked.MonthNames;

            string july = "July";

            AnsiConsole.MarkupLine($"[chartreuse2_1]Array contains '{july}' case sensitive[/]");
            if (monthNames.Contains(july))
            {
                AnsiConsole.MarkupLine($"{july} exists");
            }
            else
            {
                AnsiConsole.MarkupLine($"{july} does not exists");
            }

            AnsiConsole.WriteLine();

            july = "july";
            AnsiConsole.MarkupLine($"[chartreuse2_1]Array contains '{july}' case sensitive[/]");
            if (monthNames.Contains(july))
            {
                AnsiConsole.MarkupLine($"{july} exists");
            }
            else
            {
                AnsiConsole.MarkupLine($"{july} does not exists");
            }

            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine($"[chartreuse2_1]Array contains '{july}' case insensitive[/]");

            if (monthNames.Contains(july, StringComparer.CurrentCultureIgnoreCase))
            {
                AnsiConsole.MarkupLine($"{july} exists");
            }
            else
            {
                AnsiConsole.MarkupLine($"{july} does not exists");
            }
        }
    }
}
