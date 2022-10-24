using Microsoft.EntityFrameworkCore;
using RecordApp.Data;
using Spectre.Console.Rendering;

namespace RecordApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            using var context = new Context();

            var customers = context.Customers
                .Include(c => c.Contact)
                .ToList();

            
            AnsiConsole.Record();

            for (int index = 0; index < 10; index++)
            {
                AnsiConsole.MarkupLine($"[blue]{customers[index].CompanyName,-50}{customers[index].Contact.FirstName,-20} {customers[index].Contact.LastName}[/]");
            }
            AnsiConsole.MarkupLine("Done");
            /*
             * - Write to an HTML file, note the colors used above are used in the export
             * - Spans are used so it's not perfect, may be jagged.
             */
            File.WriteAllText("Demo.html", AnsiConsole.ExportHtml());
            Console.ReadLine();
          
        }

    }
}