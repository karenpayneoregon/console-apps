// Copyright (c) Nate McMaster.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.


/*
 * Minor modifications by Karen Payne
 */

#nullable enable
namespace GetStringApp.Classes
{
    /// <summary>
    /// Utilities for getting input from an interactive console.
    /// </summary>
    public static class Prompt
    {
        private const char Backspace = '\b';

        /// <summary>
        /// Gets a yes/no response from the console after displaying a <paramref name="prompt" />.
        /// <para>
        /// The parsing is case insensitive. Valid responses include: yes, no, y, n.
        /// </para>
        /// </summary>
        /// <param name="prompt">The question to display on the command line</param>
        /// <param name="defaultAnswer">If the user provides an empty response, which value should be returned</param>
        /// <param name="promptColor">The console color to display</param>
        /// <param name="promptBgColor">The console background color for the prompt</param>
        /// <returns>True is 'yes'</returns>
        public static bool GetYesNo(string prompt, bool defaultAnswer, ConsoleColor? promptColor = null, ConsoleColor? promptBgColor = null)
        {
            var answerHint = defaultAnswer ? "[Y/n]" : "[y/N]";
            do
            {
                Write($"{prompt} {answerHint}", promptColor, promptBgColor);
                Console.Write(' ');

                string? resp;
                using (ShowCursor())
                {
                    resp = Console.ReadLine()?.ToLower()?.Trim();
                }

                if (string.IsNullOrEmpty(resp))
                {
                    return defaultAnswer;
                }

                switch (resp)
                {
                    case "n":
                    case "no":
                        return false;
                    case "y":
                    case "yes":
                        return true;
                    default:
                        Console.WriteLine($"Invalid response '{resp}'. Please answer 'y' or 'n' or CTRL+C to exit.");
                        break;
                }
            }
            while (true);
        }


        private static void Write(string value, ConsoleColor? foreground, ConsoleColor? background)
        {
            if (foreground.HasValue)
            {
                Console.ForegroundColor = foreground.Value;
            }

            if (background.HasValue)
            {
                Console.BackgroundColor = background.Value;
            }

            Console.Write(value);

            if (foreground.HasValue || background.HasValue)
            {
                Console.ResetColor();
            }
        }

        private static IDisposable ShowCursor() => new CursorState();

        private class CursorState : IDisposable
        {
            private readonly bool _original;

            public CursorState()
            {
                try
                {
                    _original = Console.CursorVisible;
                }
                catch
                {
                    // some platforms throw System.PlatformNotSupportedException
                    // Assume the cursor should be shown
                    _original = true;
                }

                TrySetVisible(true);
            }

            private void TrySetVisible(bool visible)
            {
                try
                {
                    Console.CursorVisible = visible;
                }
                catch
                {
                    // setting cursor may fail if output is piped or permission is denied.
                }
            }

            public void Dispose()
            {
                TrySetVisible(_original);
            }
        }
    }
}