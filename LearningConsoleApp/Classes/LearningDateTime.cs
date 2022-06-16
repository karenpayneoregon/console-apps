using System;
using System.Collections.Generic;
using System.Globalization;
using static System.Globalization.DateTimeFormatInfo;
using static System.DateTime;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using UtilityLibrary.LanguageExtensions;

namespace LearningConsoleApp.Classes
{
    class LearningDateTime
    {

        /// <summary>
        /// Learning how to work with string to date time conversions simple
        /// </summary>
        public static void StringToDateTime()
        {
            AnsiConsole.Foreground = Color.Grey;
            AnsiConsole.MarkupLine($"[b]Running[/] [chartreuse2_1]{nameof(StringToDateTime).SplitCamelCase()}[/]");
            AnsiConsole.WriteLine();

            string input = "02/12/2022";
            AnsiConsole.MarkupLine($"is [chartreuse2_1]{input}[/] a [yellow]DateTime?[/]");

            if (DateTime.TryParse(input, out var dateTime1))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]No[/]");
            }

            var rule = new Rule("[chartreuse2_1]2nd attempt[/]")
            {
                Alignment = Justify.Left
            };

            AnsiConsole.Write(rule);
            input = "02/XX/2022";
            AnsiConsole.MarkupLine($"is [chartreuse2_1]{input}[/] a [yellow]DateTime?[/]");

            if (DateTime.TryParse(input, out var dateTime2))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                AnsiConsole.MarkupLine($"[red]No[/]");
            }

            AnsiConsole.MarkupLine("[chartreuse2_1]end of method[/]");

        }

        /// <summary>
        /// Learning how to take a string that needs to be converted to a date time but the time
        /// designator is odd e.g. -> a. m. rather than -> AM
        ///
        /// Note
        /// Requires using statement for
        /// using System.Globalization
        /// </summary>
        public static void TimeDesignator()
        {
            AnsiConsole.MarkupLine($"[b]Running[/] [chartreuse2_1]{nameof(TimeDesignator).SplitCamelCase()}[/]");
            AnsiConsole.WriteLine();
            const string dateTimeValue = "31/5/2022 11:00:00 a. m.";

            DateTimeFormatInfo formatInfo = new()
            {
                AMDesignator = "a. m.",
                PMDesignator = "p. m."
            };

            var dateTime = DateTime.ParseExact(
                dateTimeValue,
                "dd/M/yyyy hh:mm:ss tt",
                formatInfo);

            Console.WriteLine(dateTimeValue);
            Console.WriteLine(dateTime);

            AnsiConsole.MarkupLine("[chartreuse2_1]end of method[/]");
        }

        public static void TimeOfDayCode()
        {

            AnsiConsole.MarkupLine($"[b]Running[/] [chartreuse2_1]{nameof(TimeOfDayCode).SplitCamelCase()}[/]");
            AnsiConsole.WriteLine();

            // expressive "is" not needed
            if (Now.Hour is <= 12)
            {
                AnsiConsole.MarkupLine("[fuchsia]morning[/]");
            }

            // conventional
            if (Now.Hour <= 12)
            {
                AnsiConsole.MarkupLine("[skyblue3]morning[/]");
            }

            AnsiConsole.MarkupLine($"[cyan]Greeting[/] for {Now:T} [yellow]{DateTimeHelpers.Greetings()}[/]");
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[chartreuse2_1]end of method[/]");
        }
    }

    /// <summary>
    /// This class belongs in a separate class file but why not write it here which saves
    /// time testing than when satisfied moved to it's own class file.
    /// </summary>
    class DateTimeHelpers
    {
        /// <summary>
        /// Determine if morning
        /// </summary>
        /// <returns></returns>
        public static bool IsMorning
            => Now.Hour <= 12;

        /// <summary>
        /// Is it afternoon currently
        /// </summary>
        public static bool IsAfternoon
            => Now.Hour <= 16 && Now.Hour > 12;

        /// <summary>
        /// 
        /// </summary>
        public static bool IsEvening
            => Now.Hour is <= 20 and > 16;

        public static string Greetings() =>
            Now.Hour switch
            {
                <= 12 => "Good Morning",
                <= 16 => "Good Afternoon",
                <= 20 => "Good Evening",
                _ => "Good Night"
            };
    }
}
