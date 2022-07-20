using System.Text.RegularExpressions;

namespace UtilityLibrary.LanguageExtensions
{
    public static class SpectreConsoleHelpers
    {
        private static readonly Regex Whitespace = new(@"\s+");

        public static string Flatten(this string value)
            => value is null or "" ?
                value :
                Whitespace.Replace(value.Trim(), " ");

        /// <summary>
        /// Strip codes from a string between and including [] and remove extra spaces
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>string devoid of text with []</returns>
        /// <remarks>
        /// Try it https://dotnetfiddle.net/ijNYRq
        /// </remarks>
        public static string StripCodes(this string sender)
            => Regex.Replace(sender, @"\[[^]]*\]", "")
                .Flatten();

    }
}

