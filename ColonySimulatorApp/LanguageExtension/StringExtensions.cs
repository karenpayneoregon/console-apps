using System.Linq;
using System.Text.RegularExpressions;

namespace ColonySimulatorApp.LanguageExtension
{
    public static class StringExtensions
    {
        public static string SplitCamelCase(this string sender) =>
            string.Join(" ", Regex.Matches(sender, @"([A-Z][a-z]+)")
                .Select(m => m.Value));
    }
}
