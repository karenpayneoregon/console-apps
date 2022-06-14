using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace EPPlus1.Classes
{
    public class ConsoleOperations
    {
        public static Table DisplayTable()
        {
            return new Table()
                .RoundedBorder()
                .Alignment(Justify.Center)
                .AddColumn("Row id")
                .AddColumn("Key")
                .AddColumn("Company")
                .AddColumn("Title")
                .AddColumn("Contact")
                .AddColumn("Country")
                .AddColumn("Phone")
                .AddColumn("Modified")
                .BorderColor(Color.LightSlateGrey)
                .Title("[yellow]Customers from Excel[/]");
        }
    }
}
