using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenerateAppSettingsSqlServer.Models;

namespace GenerateAppSettingsSqlServer.Classes
{
    internal class Operations
    {
        public static void Execute(Options options)
        {
            
            var tableNames = DataOperations.DatabaseNames();

            while (true)
            {
                Console.Clear();

                AnsiConsole.MarkupLine($"[yellow]Path[/] {options.Folder}");
                AnsiConsole.MarkupLine($"[yellow]Encrypt[/] {options.UseEncryption.ToUpper()}");
                var menuItem = AnsiConsole.Prompt(MenuOperations.SelectionPrompt(tableNames));
                if (menuItem.Id != -1)
                {
                    Console.WriteLine(menuItem.Text);
                    FileOperations.WriteFile(options, menuItem.Text);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
