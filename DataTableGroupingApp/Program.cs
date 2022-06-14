using System;
using System.Data;
using System.Globalization;
using System.Linq;
using Spectre.Console;
using Spectre.Console.Extensions.Table;

namespace DataTableGroupApp
{
    /// <summary>
    /// Demonstrates two ways to present a DataTable in a grid
    /// </summary>
    partial class Program
    {
        static void Main(string[] args)
        {
            //Example2();
            Console.ReadLine();
        }

        /// <summary>
        /// Given two DataTable containers, group on Tax rate to a secondary DataTable
        /// followed by presenting in a Spectre.Console table.
        /// </summary>
        private static void Example1()
        {
            var sourceTable = GenericTable("Source");
            var groupTable = GenericTable("Grouped");

            var sourceDataTable = MockedDataTable();
            var resultDataTable = GroupData(sourceDataTable);

            foreach (DataRow row in sourceDataTable.Rows)
            {
                string[] itemArray = row.ItemArray
                    .Cast<decimal>()
                    .Select(value => value.ToString(CultureInfo.CurrentCulture))
                    .ToArray();

                sourceTable.AddRow(itemArray);
            }

            AnsiConsole.Write(sourceTable);

            foreach (DataRow row in resultDataTable.Rows)
            {
                string[] itemArray = row.ItemArray
                    .Cast<decimal>()
                    .Select(value => value.ToString(CultureInfo.CurrentCulture))
                    .ToArray();

                groupTable.AddRow(itemArray);
            }

            AnsiConsole.Write(groupTable);
        }


        /// <summary>
        /// Given two DataTable containers, group on Tax rate to a secondary DataTable
        /// followed by presenting in an NuGet package to extend Spectre.Console which
        /// kind of makes drawing a DataTable easier although all DataColumn must be
        /// of type string so we need to clone the result DataTable, change each column
        /// to type of string then import rows from the result DataTable.
        ///
        /// * If you inspect FromDataTable it would appear the author made an attempt
        ///   to convert column types to string but does not work.
        /// * Unlike Example1, only one DataTable is shown as the idea is to show
        ///   the alternate method to display data in a DataTable.
        /// </summary>
        private static void Example2()
        {
            var sourceDataTable = MockedDataTable();
            var resultDataTable = GroupData(sourceDataTable);

            // need to do this so we can use FromDataTable
            DataTable cloned = resultDataTable.Clone();

            foreach (DataColumn column in cloned.Columns)
            {
                cloned.Columns[column.ColumnName]!.DataType = typeof(string);
            }

            foreach (DataRow row in resultDataTable.Rows)
            {
                cloned.ImportRow(row);
            }

            var tableToDisplay = cloned
                .FromDataTable()
                .Border(TableBorder.Rounded)
                .Alignment(Justify.Center)
                .Title("[yellow][b]Example 2[/][/]");

            AnsiConsole.Write(tableToDisplay);
        }
    }
}
