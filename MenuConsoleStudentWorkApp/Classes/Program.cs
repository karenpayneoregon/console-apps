using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MenuConsoleAppBasic.Models;
using MenuConsoleStudentWorkApp.Classes;
using MenuConsoleStudentWorkApp.Models;
using Spectre.Console;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace MenuConsoleStudentWorkApp
{
    partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample: basically homework helper";

            W.SetConsoleWindowPosition(W.AnchorWindow.Left | W.AnchorWindow.Top);

        }

        /// <summary>
        /// Operations to perform from selection in main menu
        /// </summary>
        /// <param name="menuItem">option from main menu</param>
        /// <param name="studentList">current list of students</param>
        private static void Selection(MenuItem menuItem, List<Student> studentList)
        {
            AnsiConsole.Clear();
            
            Student student;

            switch (menuItem.Id)
            {
                case 0:
                    student = AnsiConsole.Prompt(MenuOperations.StudentMenu());
                    if (student.Id > 0)
                    {
                        Display(student);
                    }
                    break;
                case 1:
                    student = AnsiConsole.Prompt(MenuOperations.StudentMenu());
                    if (student.Id > 0)
                    {
                        Edit(student);
                    }
                    break;
                case 2:
                    student = AnsiConsole.Prompt(MenuOperations.StudentMenu());
                    if (student.Id > 0)
                    {
                        Remove(student, studentList);
                    }
                    break;
                case 3:
                    Save(studentList);
                    break;
            }
        }

        /// <summary>
        /// Display selected student properties
        /// </summary>
        /// <param name="student">student to display properties for</param>
        public static void Display(Student student)
        {
            Prompts.DisplayCurrentStudent(student);
        }

        /// <summary>
        /// Edit a student
        /// </summary>
        /// <param name="student">student to edit</param>
        public static void Edit(Student student)
        {
            Prompts.Edit(student);
        }

        /// <summary>
        /// Remove student from list
        /// </summary>
        /// <param name="student">student to remove</param>
        /// <param name="StudentList">list to remove student from</param>
        public static void Remove(Student student, List<Student> StudentList)
        {
            if (AnsiConsole.Confirm($"Remove {student.FirstName} {student.LastName}?", false))
            {
                StudentList.Remove(student);
            }
        }

        /// <summary>
        /// Place holder if data should be saved. If used the logic to
        /// load students must change as it currently creates mocked data via Bogus library
        /// </summary>
        /// <param name="list"></param>
        public static void Save(List<Student> list)
        {
            // optional, perhaps to a json file
        }
    }
}





