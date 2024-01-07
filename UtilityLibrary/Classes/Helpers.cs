using System;
using static UtilityLibrary.Classes.Environment;

namespace UtilityLibrary.Classes
{
    public class Helpers
    {
        public static string GetEnvironmentColor(Environment environment)
            => environment switch
            {
                Development => "green",
                Staging => "yellow",
                Production => "cyan",
                _ => throw new ArgumentOutOfRangeException()
            };
    }
}
