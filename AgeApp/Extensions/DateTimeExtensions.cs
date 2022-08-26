using System;
using System.Collections.Generic;
namespace myage.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsMinDate(this DateTime input)
        {
            var source = new DateTime(input.Year, input.Month, input.Day,0,0,0);

            return source == DateTime.MinValue;
        }
    }
}
