using System.Linq;
using Microsoft.EntityFrameworkCore;
using NorthWind2020ConsoleApp.Data;
using Spectre.Console;

namespace NorthWind2020ConsoleApp.Classes
{
    /// <summary>
    /// Not recommended for use in an application, simply showing
    /// anything pretty much can be colored
    /// </summary>
    public class OffTheDeepEnd
    {

        public static void Coloring()
        {
            using var context = new NorthContext();
            var query = context.Customers
                .Include(customer => customer.CountryIdentifierNavigation)
                .Include(customer => customer.Contact)
                .ThenInclude(currentContact => currentContact.ContactDevices)
                .ThenInclude(devices => devices.PhoneTypeIdentifierNavigation).ToColoredQueryString();

            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine(query);
            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine("[red].To[/][white]Colored[/][red]QueryString[/][white]()[/]");
        }
    }

    public static class ColoringExtensions
    {
        public static string ToColoredQueryString(this IQueryable source)
        {
            
            var temp = source.ToQueryString();

            temp = temp.Replace("[", "");
            temp = temp.Replace("]", "");
            temp = temp.Replace("SELECT", "[springgreen3_1]SELECT[/]");
            temp = temp.Replace("FROM", "[springgreen3_1]FROM[/]");
            temp = temp.Replace("LEFT JOIN", "[mediumpurple2]LEFT JOIN[/]");
            temp = temp.Replace("AS", "[cornflowerblue]AS[/]");
            temp = temp.Replace("ON", "[cornflowerblue]ON[/]");
            temp = temp.Replace("(", "[white]([/]");
            temp = temp.Replace(")", "[white])[/]");

            return temp;
        }
    }
}
