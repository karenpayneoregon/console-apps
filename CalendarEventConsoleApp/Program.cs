using System;
using Spectre.Console;
using static System.DateTime;

namespace CalendarEventConsoleApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            ThisMonth();

            NextMonth();

            Console.ReadLine();
        }

        private static void ThisMonth()
        {
            var currentMonth = new Calendar(Now.Year, Now.Month);
            currentMonth.AddCalendarEvent(currentMonth.Year, currentMonth.Month, 5);
            currentMonth.AddCalendarEvent(currentMonth.Year, currentMonth.Month, 12);
            currentMonth.AddCalendarEvent(currentMonth.Year, currentMonth.Month, 20);
            currentMonth.AddCalendarEvent(currentMonth.Year, currentMonth.Month, 11);
            currentMonth.AddCalendarEvent(currentMonth.Year, currentMonth.Month, 18);
            currentMonth.HighlightStyle(Style.Parse("cyan bold"));
            currentMonth.HeaderStyle(Style.Parse("red"));
            currentMonth.ShowHeader();
            currentMonth.Alignment(Justify.Center);
            AnsiConsole.Write(currentMonth);
        }

        private static void NextMonth()
        {
            var nextMonth = new Calendar(Now.Year, Now.Month + 1);
            nextMonth.AddCalendarEvent(nextMonth.Year, nextMonth.Month, 20);
            nextMonth.HighlightStyle(Style.Parse("yellow bold"));
            nextMonth.ShowHeader();
            nextMonth.HeaderStyle(Style.Parse("cyan"));
            nextMonth.Alignment(Justify.Center);
            AnsiConsole.Write(nextMonth);
        }
    }
}
