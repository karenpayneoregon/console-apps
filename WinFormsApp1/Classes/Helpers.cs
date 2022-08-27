using System.Text.RegularExpressions;

namespace WinFormsApp1.Classes;

public static class Helpers
{
    public static string NextValue(this string sender)
    {
        string value = Regex.Match(sender, "[0-9]+$").Value;
        return sender[..^value.Length] + (long.Parse(value) + 1)
            .ToString().PadLeft(value.Length, '0');
    }
}