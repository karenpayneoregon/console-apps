using System.Text.RegularExpressions;

namespace DependencyInjectionSimple.LanguageExtensions;

public static class StringExtensions
{

    /// <summary>
    /// Use to split on upper cased characters and separate with a single space.
    /// </summary>
    public static string SplitCamelCase(this string sender) =>
        string.Join(" ", Regex.Matches(sender, @"([A-Z][a-z]+)")
            .Select(m => m.Value));


}