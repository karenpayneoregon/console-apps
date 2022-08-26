using Spectre.Console;
using SqlServerColumnDescriptions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerColumnDescriptions.Classes
{
    public class Worker
    {
        public static void Execute()
        {
            DatabaseName databaseName = new DatabaseName() { Id = 0 };

            while (databaseName.Id != -1)
            {
                AnsiConsole.Clear();

                databaseName = AnsiConsole.Prompt(MenuOperations.DatabaseNamesMenu());

                if (databaseName.Id == -1)
                {
                    return;
                }

                List<DatabaseTable> result = DataOperations.GetDetails(databaseName.Name);
                if (result.Count == 0)
                {
                    AnsiConsole.MarkupLine($"[cyan]{databaseName.Name}[/] has no columns with descriptions press and key for menu");
                    Console.ReadLine();
                }
                else
                {
                    AnsiConsole.MarkupLine($"Database: [yellow]{databaseName.Name}[/]");
                    var resultTable = new Table()
                        .RoundedBorder()
                        .AddColumn("[b]Column name[/]")
                        .AddColumn("[b]Description[/]")
                        .Alignment(Justify.Left)
                        .BorderColor(Color.LightSlateGrey);


                    foreach (var table in result)
                    {
                        resultTable.AddRow($"[yellow]{table.TableName}[/]");
                        foreach (var col in table.ColumnsList)
                        {
                            resultTable.AddRow(col.Name, col.Description);
                        }
                    }

                    AnsiConsole.Write(resultTable);
                    AnsiConsole.MarkupLine("[yellow]Press a key for the menu[/]");
                    Console.ReadLine();
                }
            }
        }
    }
}
