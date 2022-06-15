//#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using AskConsoleApp.Classes;
using AskConsoleApp.Models;
using Spectre.Console;
using Spectre.Console.Rendering;
using static System.Globalization.DateTimeFormatInfo;
using static System.DateTime;


namespace AskConsoleApp
{
    partial class Program
    {
        static void Main(string[] args)
        {

            


            //OldSchool();
            CurrentSchool();
            Console.ReadLine();
        }

        private static void CurrentSchool()
        {
            Person person = Person();

            Console.Clear();
            Console.WriteLine();

            Console.WriteLine($"Name: {person.FullName}");
            Console.WriteLine($" Age: {person.Age()}");

            if (person.FavoriteMonths.Any())
            {
                Console.WriteLine("Favorite months");
                foreach (var month in person.FavoriteMonths)
                {
                    Console.WriteLine($"{month,12}");
                }
            }
            else
            {
                Console.WriteLine("No favorite months selected");
            }

            AnsiConsole.Markup("Press [yellow]any[/] key to close");

        }

        private static void OldSchool()
        {
            
            Console.WriteLine("What is your name?");

            Console.Write("Type your first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Type your last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Type your age: ");
            string ageValue = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(lastName))
            {
                lastName = "[unknown last name]";
            }

            if (string.IsNullOrWhiteSpace(firstName))
            {
                firstName = "[unknown first name]";
            }

            Console.WriteLine(int.TryParse(ageValue, out var age) ? $"Hello, {firstName} {lastName} {age}" : $"Hello, {firstName} {lastName}");
        }

        /// <summary>
        /// Ask user for details
        /// </summary>
        /// <returns></returns>
        public static Person Person() =>
            new()
            {
                FirstName = Prompts.GetFirstName(),
                LastName = Prompts.GetLastName(),
                BirthDate = Prompts.GetBirthDate(),
                FavoriteMonths = Prompts.GetFavoriteMonths()
            };

        private static void PanelBorders()
        {
            static IRenderable CreatePanel(string name, BoxBorder border)
            {
                return new Panel($"This is a panel with\nthe [yellow]{name}[/] border. Solution folders are used to separate various third party libraries used to work with user interfaces for console projects.")
                    .Header($" [cyan]{name}[/] ", Justify.Center)
                    .Border(border)
                    .BorderStyle(Style.Parse("grey"))
                    .HeaderAlignment(Justify.Center);
            }

            var items = new[]
            {
                CreatePanel("Square", BoxBorder.Square),
                //CreatePanel("Double", BoxBorder.Double),
            };

            AnsiConsole.Write(
                new Padder(
                    new Columns(items).PadRight(1),
                    new Padding(2, 0, 20, 0)));
        }

        private static void TableBorders()
        {
            static IRenderable CreateTable(string name, TableBorder border)
            {
                var table = new Table().Border(border);
                table.AddColumn("[yellow]Header 1[/]", c => c.Footer("[grey]Footer 1[/]"));
                table.AddColumn("[yellow]Header 2[/]", col => col.Footer("[grey]Footer 2[/]").RightAligned());
                table.AddRow("Cell", "Cell");
                table.AddRow("Cell", "Cell");

                return new Panel(table).Header($" [blue]{name}[/] ", Justify.Center).NoBorder();
            }

            var items = new[]
            {
                CreateTable("Ascii", TableBorder.Ascii),
                CreateTable("Ascii2", TableBorder.Ascii2),
                CreateTable("AsciiDoubleHead", TableBorder.AsciiDoubleHead),
                CreateTable("Horizontal", TableBorder.Horizontal),
                CreateTable("Simple", TableBorder.Simple),
                CreateTable("SimpleHeavy", TableBorder.SimpleHeavy),
                CreateTable("Minimal", TableBorder.Minimal),
                CreateTable("MinimalHeavyHead", TableBorder.MinimalHeavyHead),
                CreateTable("MinimalDoubleHead", TableBorder.MinimalDoubleHead),
                CreateTable("Square", TableBorder.Square),
                CreateTable("Rounded", TableBorder.Rounded),
                CreateTable("Heavy", TableBorder.Heavy),
                CreateTable("HeavyEdge", TableBorder.HeavyEdge),
                CreateTable("HeavyHead", TableBorder.HeavyHead),
                CreateTable("Double", TableBorder.Double),
                CreateTable("DoubleEdge", TableBorder.DoubleEdge),
                CreateTable("Markdown", TableBorder.Markdown),
            };

            AnsiConsole.Write(new Columns(items).Collapse());
        }

        private static void HorizontalRule(string title)
        {
            AnsiConsole.WriteLine();
            AnsiConsole.Write(new Rule($"[white bold]{title}[/]").RuleStyle("grey").LeftAligned());
            AnsiConsole.WriteLine();
        }





        private static List<string> GetFavoriteMonths() => AnsiConsole.Prompt
            (
                new MultiSelectionPrompt<string>()
                    .PageSize(12)
                    // permit no choice
                    .Required(false)
                    .Title("What are your [cyan]favorite months[/]?")
                    .InstructionsText("[grey](Press [yellow]<space>[/] to toggle a month, [yellow]<enter>[/] to accept)[/] or [red]Enter[/] w/o any selections to cancel")
                    .AddChoices(CurrentInfo!.MonthNames[..^1])
                    .HighlightStyle(new Style(Color.White, Color.Black, Decoration.Invert))
            );

        
        public static string AskSport()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<string>("What's your [green]favorite sport[/]?")
                    .InvalidChoiceMessage("[red]That's not a sport![/]")
                    .DefaultValue("Sport?")
                    .AddChoice("[white]Soccer[/]")
                    .AddChoice("Hockey")
                    .AddChoice("Basketball"));
        }


    }

    public class SportsSurvey
    {
        public static List<SportItem> List = new()
        {
            new() { Name = "Soccer", Color = Color.Yellow, Count = 58 },
            new() { Name = "Golf", Color = Color.Green, Count = 21 },
            new() { Name = "Baseball", Color = Color.White, Count = 79 },
            new() { Name = "Ice Hockey", Color = Color.Red, Count = 39 },
        };
    }

    public class SportItem
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public Color Color { get; set; }
    }
}
