#nullable disable
using System;
using System.Diagnostics.CodeAnalysis;
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

        static string AskUsernameIfMissing(string current)
            => !string.IsNullOrWhiteSpace(current)
                ? current
                : AnsiConsole.Prompt(
                    new TextPrompt<string>("What's the username?")
                        .Validate(username
                            => !string.IsNullOrWhiteSpace(username)
                                ? ValidationResult.Success()
                                : ValidationResult.Error("[yellow]Invalid username[/]")));

        static string AskPasswordIfMissing(string current)
            => TryGetValidPassword(current, out var validPassword)
                ? validPassword
                : AnsiConsole.Prompt(
                    new TextPrompt<string>("What's the password?")
                        .Secret()
                        .Validate(password
                            => TryGetValidPassword(password, out _)
                                ? ValidationResult.Success()
                                : ValidationResult.Error("[yellow]Invalid password[/]")));

        static bool TryGetValidPassword(string? password, [NotNullWhen(true)] out string? validPassword)
        {
            var isValidPassword = !string.IsNullOrWhiteSpace(password) && password.Length > 2;
            validPassword = password;
            return isValidPassword;
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