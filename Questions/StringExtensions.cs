namespace Questions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Trim from start a given string
        /// </summary>
        /// <param name="target">String to work on</param>
        /// <param name="trimString">String to remove from start of <see cref="target"/></param>
        /// <returns>Original string if not starting with <see cref="trimString"/> or <see cref="target"/> minus<see cref="trimString"/></returns>
        public static string RemoveFromStart(this string target, string trimString)
        {
            if (string.IsNullOrWhiteSpace(trimString)) return target;

            string result = target;
            while (result.StartsWith(trimString))
            {
                result = result[trimString.Length..];
            }

            return result;
        }
    }
}