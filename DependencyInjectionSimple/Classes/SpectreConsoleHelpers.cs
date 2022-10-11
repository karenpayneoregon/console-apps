using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionSimple.Classes
{
    public class SpectreConsoleHelpers
    {
        public static void ExitPrompt()
        {
            Console.WriteLine();
            Render(new Rule($"[yellow]Press[/] [cyan]ENTER[/] [yellow]to exit the demo[/]").RuleStyle(Style.Parse("silver")).Centered());
            Console.ReadLine();
        }
        private static void Render(Rule rule)
        {
            AnsiConsole.Write(rule);
            AnsiConsole.WriteLine();
        }
    }
}
