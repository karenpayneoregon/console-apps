using Spectre.Console;
using SqlServerColumnDescriptions.Models;


namespace SqlServerColumnDescriptions.Classes;

public class Worker
{
    /// <summary>
    /// * Present a menu of database
    ///     * Traverse database tables
    ///     * If at least one column in a table has a description add to list else bypass it
    ///     * Display details
    /// </summary>
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

            var (list, exception) = DataOperations.GetDetails(databaseName.Name);
            if (list.Count == 0)
            {
                if (exception is not null)
                {
                    AnsiConsole.WriteException(exception);
                }
                else
                {
                    AnsiConsole.MarkupLine($"[cyan]{databaseName.Name}[/] has no columns with descriptions press and key for menu");
                }
                AnsiConsole.MarkupLine("Press [cyan]Enter[/] for menu");
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


                foreach (var table in list)
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