using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
