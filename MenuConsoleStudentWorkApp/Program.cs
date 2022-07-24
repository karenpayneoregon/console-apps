using System;
using System.Collections.Generic;
using MenuConsoleAppBasic.Models;
using MenuConsoleStudentWorkApp.Classes;
using MenuConsoleStudentWorkApp.Models;
using Spectre.Console;

namespace MenuConsoleStudentWorkApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            MenuItem menuItem = new MenuItem();

            List<Student> StudentList = BogusOperations.GetStudents();

            while (menuItem.Id > -1)
            {
                AnsiConsole.Clear();
                AnsiConsole.Write(
                    new Panel(new Text("Homework helper").Centered())
                        .Expand()
                        .SquareBorder()
                        .BorderStyle(new Style(Color.Cornsilk1))
                        .Header("[LightGreen]About[/]")
                        .HeaderAlignment(Justify.Center));
                menuItem = AnsiConsole.Prompt(MenuOperations.MainMenu());
                Selection(menuItem, StudentList);
            }

        }
    }
}
