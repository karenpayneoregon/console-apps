using System;
using System.Runtime.CompilerServices;
using AskConsoleApp2.Classes;
using AskConsoleApp2.Models;
using Spectre.Console;

namespace AskConsoleApp2
{
    partial class Program
    {
        static void Main(string[] args)
        {
            UserChoices userChoices = Configuration.Get();

            Table table = new Table()
                .RoundedBorder()
                .AddColumn("[b]Setting[/]")
                .AddColumn("[b]Value[/]")
                .Alignment(Justify.Center)
                .BorderColor(Color.LightSlateGrey)
                .Title("[LightGreen]Choices[/]");


            table.AddRow("PasswordLength", userChoices.PasswordLength.ToString());
            table.AddRow("UseNumbers", userChoices.UseNumbers.ToYesNo());
            table.AddRow("UseOtherSigns", userChoices.UseOtherSigns.ToYesNo());
            table.AddRow("UseUppercaseLetters", userChoices.UseUppercaseLetters.ToYesNo());

            AnsiConsole.Clear();
            AnsiConsole.Write(table);

            AnsiConsole.MarkupLine("[LightGreen]Press a key to close[/]");
            Console.ReadLine();
        }

        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample";
        }
    }
}
