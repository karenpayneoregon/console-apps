using System;
using static System.Console;

namespace MarkOfTheWeb.Classes
{
    public static class ConsoleColors
    {
        public static void WriteLineYellow(string message, bool line = false)
        {
            var originalForeColor = ForegroundColor;

            ForegroundColor = ConsoleColor.Yellow;

            WriteLine(message);

            ForegroundColor = originalForeColor;

            if (line)
            {
                WriteLine(new string('-', 100));
            }

            ResetColor();
        }
        public static void WriteLineCyan(string message, bool line = false)
        {
            var originalForeColor = ForegroundColor;

            ForegroundColor = ConsoleColor.Cyan;

            WriteLine(message);

            ForegroundColor = originalForeColor;

            if (line)
            {
                WriteLine(new string('-', 100));
            }

            ResetColor();
        }
        public static void WriteLineGreen(string message, bool line = false)
        {
            var originalForeColor = ForegroundColor;

            ForegroundColor = ConsoleColor.Green;

            WriteLine(message);

            ForegroundColor = originalForeColor;

            if (line)
            {
                WriteLine(new string('-', 100));
            }

            ResetColor();
        }

        public static void WriteLineRed(string message, bool line = false)
        {
            var originalForeColor = ForegroundColor;

            ForegroundColor = ConsoleColor.Red;

            WriteLine(message);

            ForegroundColor = originalForeColor;

            if (line)
            {
                WriteLine(new string('-', 100));
            }

            ResetColor();
        }

        public static void WriteGreen(string message)
        {
            var originalForeColor = ForegroundColor;

            ForegroundColor = ConsoleColor.Green;
            Write(message);
            ForegroundColor = originalForeColor;

            ResetColor();
        }
        public static void WriteLineBold(string message, bool line = false)
        {
            var originalForeColor = ForegroundColor;

            ForegroundColor = ConsoleColor.White;

            WriteLine(message);

            ForegroundColor = originalForeColor;

            if (line)
            {
                WriteLine(new string('-', 100));
            }

            ResetColor();
        }

    }
}
