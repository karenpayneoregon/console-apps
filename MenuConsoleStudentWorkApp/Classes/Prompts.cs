using System;
using MenuConsoleStudentWorkApp.Models;
using Spectre.Console;

namespace MenuConsoleStudentWorkApp.Classes
{
    public class Prompts
    {

        public static void DisplayCurrentStudent(Student student)
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[cyan]Current student values[/]");
            AnsiConsole.MarkupLine($"[b]Identifier:[/] {student.Id}");
            AnsiConsole.MarkupLine($"[b]First name:[/] {student.FirstName}");
            AnsiConsole.MarkupLine($" [b]Last name:[/] {student.LastName}");
            AnsiConsole.MarkupLine($"     [b]Grade:[/] {student.Grade}");
            Console.ReadLine();
        }

        /// <summary>
        /// Same code as <see cref="Edit"/> which expects values for each property, for this method
        /// simply pass in a new student without setting any properties. Once done add the Student to
        /// <see cref="BogusOperations.Students"/>
        /// </summary>
        /// <param name="student">new student without any properties set</param>
        public static void Create(Student student)
        {
            student.FirstName = FirstName(student.FirstName);
            student.LastName = LastName(student.LastName);
            student.Grade = Grade(student.Grade);

            /*
             * TODO, get last student id and increment by 1 and set to Id property
             */

        }
        public static void Edit(Student student)
        {
            student.FirstName = FirstName(student.FirstName);
            student.LastName = LastName(student.LastName);
            student.Grade = Grade(student.Grade);
        }

        public static string FirstName(string sender) =>
            AnsiConsole.Prompt(
                new TextPrompt<string>("[white]First name[/]?")
                    .PromptStyle("yellow")
                    .DefaultValue(sender)
                    .Validate(value => value.Length switch
                    {
                        < 3 => ValidationResult.Error("[red]Must have at least three characters[/]"),
                        _ => ValidationResult.Success(),
                    })
                    .ValidationErrorMessage("[red]Please enter your first name[/]"));



        public static string LastName(string sender) =>
            AnsiConsole.Prompt(
                new TextPrompt<string>("[white]Last name[/]?")
                    .PromptStyle("yellow")
                    .DefaultValue(sender)
                    .ValidationErrorMessage("[red]Please enter your last name[/]"));

        public static int Grade(int sender) =>
            AnsiConsole.Prompt(
                new TextPrompt<int>("[white]Grade[/]?")
                    .PromptStyle("yellow")
                    .DefaultValue(sender)
                    .Validate(grade => grade switch
                    {
                        < 1 => ValidationResult.Error("[red]Must be 1 to 100[/]"),
                        > 100 => ValidationResult.Error("[red]Must be 1 to 100[/]"),
                        _ => ValidationResult.Success(),
                    })
                    .ValidationErrorMessage("[red]Please enter a grade[/]"));
    }
}
