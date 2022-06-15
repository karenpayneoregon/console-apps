using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace MarkOfTheWeb.Classes
{
    public class Operations
    {
        public static void RemoveMarkOfWeb(CommandLineOptions options)
        {
            try
            {
                if (Directory.Exists(options.Directory))
                {
                    ConsoleColors.WriteLineGreen($"Working on {options.Directory}");
                    Utilities.UnblockFiles(options.Directory);
                    ConsoleColors.WriteLineBold("Done");
                    ConsoleWaiter.ReadLineWithTimeout();
                }
                else
                {
                    ConsoleColors.WriteLineRed("Folder does not exists");
                    Console.WriteLine(options.Directory);
                    ConsoleWaiter.ReadLineWithTimeout();
                    Environment.Exit(-1);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                ConsoleWaiter.ReadLineWithTimeout();
                Environment.Exit(-1);
            }
        }
    }
}
