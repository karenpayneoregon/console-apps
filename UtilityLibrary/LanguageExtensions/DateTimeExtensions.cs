using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.Models;

namespace UtilityLibrary.LanguageExtensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Provides a wrapper for <see cref="GetElapsedTime"/> to keep client code clean
        /// </summary>
        /// <param name="fromDateTime">Pass date</param>
        /// <param name="toDate">Typically DateTime.Now</param>
        /// <returns><see cref="Age"/> instance</returns>
        /// <remarks>
        /// * Minimal assertion is done
        /// * milliseconds are provides but not much use
        /// </remarks>
        public static Age Age(this DateTime fromDateTime, DateTime toDate)
        {

            fromDateTime.GetElapsedTime(toDate,
                out var years, out var months, out var days,
                out var hours, out var minutes, out var seconds,
                out _);

            return new Age()
            {
                Years = years,
                Months = months,
                Days = days,
                Hours = hours,
                Minutes = minutes,
                Seconds = seconds,
                From = fromDateTime,
                To = toDate
            };

        }
        /// <summary>
        /// Get elapsed time in years, months, days, hours, seconds
        /// </summary>
        /// <param name="fromDate">Date in past</param>
        /// <param name="toDate">Date pass fromDate</param>
        /// <param name="years"></param>
        /// <param name="months"></param>
        /// <param name="days"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <param name="milliseconds"></param>
        public static void GetElapsedTime(this DateTime fromDate, DateTime toDate, out int years, out int months, out int days, out int hours, out int minutes, out int seconds, out int milliseconds)
        {
            // If from_date > to_date, switch them around.
            if (fromDate > toDate)
            {
                GetElapsedTime(
                    toDate,
                    fromDate,
                    out years,
                    out months,
                    out days,
                    out hours,
                    out minutes,
                    out seconds,
                    out milliseconds);

                years = -years;
                months = -months;
                days = -days;
                hours = -hours;
                minutes = -minutes;
                seconds = -seconds;
                milliseconds = -milliseconds;
            }
            else
            {
                // Handle the years.
                years = toDate.Year - fromDate.Year;

                // See if we went too far.
                DateTime testDate = fromDate.AddMonths(12 * years);

                if (testDate > toDate)
                {
                    years--;
                    testDate = fromDate.AddMonths(12 * years);
                }

                // Add months until we go too far.
                months = 0;

                while (testDate <= toDate)
                {
                    months++;
                    testDate = fromDate.AddMonths(12 * years + months);
                }

                months--;

                // Subtract to see how many more days,
                // hours, minutes, etc. we need.
                fromDate = fromDate.AddMonths(12 * years + months);

                TimeSpan remainder = toDate - fromDate;

                days = remainder.Days;
                hours = remainder.Hours;
                minutes = remainder.Minutes;
                seconds = remainder.Seconds;
                milliseconds = remainder.Milliseconds;

            }
        }

        /// <summary>
        /// Format a TimeSpan with AM PM
        /// </summary>
        /// <param name="sender">TimeSpan to format</param>
        /// <param name="format">Optional format</param>
        /// <returns></returns>
        public static string Formatted(this TimeSpan sender, string format = "hh:mm tt") => DateTime.Today.Add(sender).ToString(format);
    }
}
