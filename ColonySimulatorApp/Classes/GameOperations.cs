using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColonySimulatorApp.Classes
{
    /// <summary>
    /// Stubbed just enough for menu selections, for a real
    /// app there would be properties and perhaps a builder pattern
    /// and most likely events
    /// </summary>
    public class GameOperations
    {
        public static void Next()
        {
            Console.WriteLine(nameof(Next));
        }
        public static void Build()
        {
            Console.WriteLine(nameof(Build));
        }

        public static void Job()
        {
            Console.WriteLine(nameof(Job));
        }
    }
}
