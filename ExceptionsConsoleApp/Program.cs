using System;
using System.IO;
using ExceptionsConsoleApp.Classes;
using ExceptionsConsoleApp.Extensions;
using Spectre.Console;

namespace ExceptionsConsoleApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Disasters.FileDoesNotExists();
            Console.WriteLine();
            Disasters.WrongType("Oooops");
            Console.ReadLine();
        }
    }

    public class Disasters
    {
        public static void FileDoesNotExists()
        {

            var rule = new Rule($"[yellow]{nameof(FileDoesNotExists).SplitCamelCase()}[/]")
            {
                Alignment = Justify.Left,
                Style = Style.Parse("white")
            };

            AnsiConsole.Write(rule);

            try
            {
                File.ReadAllLines("NonExistingFile.txt");
            }
            catch (Exception localException)        
            {
                ExceptionHelpers.ColorStandard(localException);
            }
        }
        public static void WrongType(object sender)
        {
            var rule = new Rule($"[yellow]{nameof(WrongType).SplitCamelCase()}[/]")
            {
                Alignment = Justify.Left,
                Style = Style.Parse("white")
            };

            AnsiConsole.Write(rule);

            try
            {
                decimal value = Convert.ToDecimal(sender);
            }
            catch (Exception localException)
            {
                ExceptionHelpers.ColorWithCyanFuchsia(localException);
            }
        }
    }
}
