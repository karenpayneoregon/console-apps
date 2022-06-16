using Spectre.Console;
using UtilityLibrary.LanguageExtensions;

namespace LearningConsoleApp.Classes
{
    class LearningNumbers
    {
        public static void GetDecimalFraction()
        {
            AnsiConsole.MarkupLine($"[b]Running[/] [yellow]{nameof(GetDecimalFraction).SplitCamelCase()}[/]");
            AnsiConsole.WriteLine();

            decimal value = 12.1234m;
            AnsiConsole.MarkupLine($"Value: [white on red]{value}[/]");
            AnsiConsole.MarkupLine($"       Fraction raw {value % 1.0m}");
            AnsiConsole.MarkupLine($" Fraction extension {value.Fraction()}");
            AnsiConsole.MarkupLine($"     Decimal places {value.DecimalPlaces()}");
            AnsiConsole.MarkupLine("[yellow]end of method[/]");
        }
    }

    /// <summary>
    /// This class belongs in a separate class file but why not write it here which saves
    /// time testing than when satisfied moved to it's own class file.
    /// </summary>
    static class Extensions
    {
        /// <summary>
        /// Get fractional part of a number
        /// </summary>
        /// <param name="sender">decimal with a value</param>
        /// <returns>Fraction of <see cref="sender"/></returns>
        public static decimal Fraction(this decimal sender) => sender % 1.0m;

        /// <summary>
        /// Get decimal places
        /// </summary>
        /// <param name="sender">decimal with a value</param>
        /// <returns>decimal places to the right</returns>
        public static decimal DecimalPlaces(this decimal sender)
        {

            int[] bits = decimal.GetBits(sender);
            ulong lowInt = (uint)bits[0];
            ulong midInt = (uint)bits[1];
            int exponent = (bits[3] & 0x00FF0000) >> 16;
            int result = exponent;

            ulong lowDecimal = lowInt | (midInt << 32);

            while (result > 0 && (lowDecimal % 10) == 0)
            {
                result--;
                lowDecimal /= 10;
            }

            return result;
        }
    }
}
