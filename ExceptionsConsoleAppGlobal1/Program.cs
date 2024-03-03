using ExceptionsConsoleAppGlobal1.Classes;
using Spectre.Console;

namespace ExceptionsConsoleAppGlobal1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var title = "Local exception".CenterText(maxLength: 36, c: (char)32);
            var table = CreateTable(title: title);
            AnsiConsole.Write(renderable: table);



            try
            {
                File.ReadAllLines(path: @"C:\Temp\NonExistingFile.txt");
            }
            catch (Exception localException)
            {
                localException.ColorWithCyanFuchsia();
            }
            
            table.Rows.Clear();
            title ="Unhandled exception".CenterText(maxLength: 36, c: (char)32);
            table.AddRow(columns: $"[white on red]{title}[/]");
            AnsiConsole.Write(renderable: table);

            var boom = args[12];
        }


    }
}
