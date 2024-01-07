using MenuConsoleAppBasic.Models;
using MenuConsoleStudentWorkApp.Models;
using Spectre.Console;


namespace MenuConsoleStudentWorkApp.Classes
{
    public class MenuOperations
    {
        private static Style HighLightStyle => new(
            Color.LightGreen,
            Color.Black,
            Decoration.None);

        public static SelectionPrompt<MenuItem> MainMenu()
        {

            SelectionPrompt<MenuItem> menu = new()
            {
                HighlightStyle = HighLightStyle
            };

            menu.Title("Select an [B]option[/]");
            menu.AddChoices(new List<MenuItem>()
            {
                new() {Id = 0,  Text = "List students"},
                new() {Id = 1,  Text = "Edit an student"},
                new() {Id = 2,  Text = "Delete student"},
                new() {Id = 3,  Text = "Save all"},
                new() {Id = -1, Text = "Exit"},
            });

            return menu;
        }

        public static SelectionPrompt<Student> StudentMenu()
        {

            SelectionPrompt<Student> menu = new()
            {
                HighlightStyle = HighLightStyle
            };

            menu.Title("Select a [B]Student[/]");
            menu.AddChoices(FileOperations.GetStudents());

            return menu;
        }

    }
}
