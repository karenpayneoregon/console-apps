﻿namespace AskConsoleApp2.Classes
{
    public static class StringExtensions
    {
        public static string ToYesNo(this bool value)
            => value ? "Yes" : "No";
    }
}