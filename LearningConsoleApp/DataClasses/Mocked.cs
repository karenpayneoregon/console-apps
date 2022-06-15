using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Globalization.DateTimeFormatInfo;

namespace LearningConsoleApp.DataClasses
{
    public class Mocked
    {
        public static string[] MonthNames => CurrentInfo!.MonthNames[..^1];
        public static string[] MonthNamesUpperCased => 
            MonthNames.Select(monthName => monthName.ToUpper()).ToArray();
    }
}
