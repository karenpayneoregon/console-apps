namespace ExceptionsConsoleAppGlobal1.Classes;
internal static class StringExtensions
{
    /// <summary>
    /// Center text to a specific width with a specific character
    /// </summary>
    /// <param name="input">text to center</param>
    /// <param name="maxLength">Width of final output</param>
    /// <param name="c">character for centering text</param>
    /// <returns>Centered text between char</returns>
    public static string CenterText(this string input, int maxLength, char c)
    {
        input = input.Insert(startIndex: input.Length, value: " ").Insert(startIndex: 0, value: " ");

        return input.Length > maxLength
            ? input.Substring(startIndex: 0, length: maxLength - 3).Insert(startIndex: maxLength - 3, value: " ")
                .PadLeft(totalWidth: maxLength - 1, paddingChar: c)
                .PadRight(totalWidth: maxLength, paddingChar: c)
            : input.PadLeft(
                    totalWidth: input.Length + ((maxLength - input.Length) / 2) +
                                (((maxLength - input.Length) % 2 != 1) ? 0 : 1), paddingChar: c)
                .PadRight(totalWidth: input.Length + (maxLength - input.Length), paddingChar: c);
    }
}
