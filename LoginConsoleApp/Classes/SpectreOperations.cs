using System;
using System.Runtime.CompilerServices;
using Spectre.Console;

namespace LoginConsoleApp.Classes
{
    /// <summary>
    /// Helper methods for asking for input from user along with displaying banners
    /// </summary>
    public class SpectreOperations
    {
        public static string AskLoginName()
        {
            var name = AnsiConsole.Ask<string>("[thistle1]Login name[/]?");
            return name;
        }

        public static string AskPassword()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>("[thistle1]Password[/]?")
                    .PromptStyle("grey50")
                    .Secret());
        }

        public static void DrawHeader()
        {
            Render(
                new Rule()
                    .RuleStyle(Style.Parse("green"))
                    .HeavyBorder()
                    .LeftAligned());

            AnsiConsole.Write(new FigletText("Enter credentials").Centered().Color(Color.Green));

            Render(
                new Rule()
                    .RuleStyle(Style.Parse("green"))
                    .HeavyBorder()
                    .LeftAligned());
        }

        public static void DrawWelcomeHeader()
        {
            Render(
                new Rule()
                    .RuleStyle(Style.Parse("white"))
                    .HeavyBorder()
                    .LeftAligned());

            AnsiConsole.Write(new FigletText("Welcome")
                .Centered()
                .Color(Color.White));

            Render(
                new Rule()
                    .RuleStyle(Style.Parse("white"))
                    .HeavyBorder()
                    .LeftAligned());
        }

        public static void DrawGoAwayHeader()
        {
            Render(
                new Rule()
                    .RuleStyle(Style.Parse("red"))
                    .HeavyBorder()
                    .LeftAligned());

            AnsiConsole.Write(new FigletText("Guards, an intruder ")
                .Centered()
                .Color(Color.Yellow));

            Render(
                new Rule()
                    .RuleStyle(Style.Parse("red"))
                    .HeavyBorder()
                    .LeftAligned());
        }
        public static void CanNotContinueHeader()
        {
            Render(
                new Rule()
                    .RuleStyle(Style.Parse("red"))
                    .HeavyBorder()
                    .LeftAligned());

            AnsiConsole.Write(new FigletText("Error 1X")
                .Centered()
                .Color(Color.Red));

            Render(
                new Rule()
                    .RuleStyle(Style.Parse("red"))
                    .HeavyBorder()
                    .LeftAligned());
        }
        public static void Render(Rule rule)
        {
            AnsiConsole.Write(rule);
            AnsiConsole.WriteLine();
        }

        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample - Spectre.Console/protobuf-net login";
        }
    }
}