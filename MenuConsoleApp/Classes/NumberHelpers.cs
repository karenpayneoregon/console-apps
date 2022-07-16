using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuConsoleApp.Classes
{
    public class NumberHelpers
    {
        public static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();

            var result = random.NextDouble() * (maximum - minimum) + minimum;
            return Math.Truncate(100 * result) / 100;
        }
    }
}
