using Microsoft.EntityFrameworkCore;
using RecordApp.Data;

namespace RecordApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            using var context = new Context();
            
            var test = Array.Empty<string>();
            var list = new List<string>(0);

            var customers = context.Customers
                .Include(c => c.Contact)
                .ToList();

            
            AnsiConsole.Record();

            for (int index = 0; index < 10; index++)
            {
                AnsiConsole.MarkupLine(
                    $"[blue]{customers[index].CompanyName,-50}"+ 
                    $"{customers[index].Contact.FirstName,-20} "+ 
                    $"{customers[index].Contact.LastName}[/]");
            }

            AnsiConsole.MarkupLine("Done");
            File.WriteAllText("Demo.html", AnsiConsole.ExportHtml());
            Console.ReadLine();
          
        }

    }
}