using System;
using System.Drawing;

namespace ConsoleHelperLibrary.Classes
{
    public class WriteUtility
    {
        /// <summary>
        /// Center text in window horizontally and vertical
        /// </summary>
        /// <param name="lines"></param>
        public static void CenterLines(params string[] lines)
        {
            
            int verticalStart = (Console.WindowHeight - lines.Length) / 2;
            int verticalPosition = verticalStart;

            for (var index = 0; index < lines.Length; index++)
            {
                var line = lines[index];
                int horizontalStart = (Console.WindowWidth - line.Length) / 2;
                Console.SetCursorPosition(horizontalStart, verticalPosition);
                Console.Write(line);
                ++verticalPosition;
            }
        }

        public static void CenterLines(ConsoleColor foreColor, params string[] lines)
        {
            Console.ForegroundColor = foreColor;
            int verticalStart = (Console.WindowHeight - lines.Length) / 2;
            int verticalPosition = verticalStart;

            for (var index = 0; index < lines.Length; index++)
            {
                var line = lines[index];
                int horizontalStart = (Console.WindowWidth - line.Length) / 2;
                Console.SetCursorPosition(horizontalStart, verticalPosition);
                Console.Write(line);
                ++verticalPosition;
            }

            Console.ResetColor();
        }
    }
}
