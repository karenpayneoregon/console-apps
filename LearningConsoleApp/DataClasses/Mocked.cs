using System.Linq;
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
