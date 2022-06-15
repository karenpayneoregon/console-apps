using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NorthWind2020ConsoleApp.Data;
using NorthWind2020Library.Models;

namespace NorthWind2020Library.Classes
{
    public class CustomerOperations
    {
        private static string _jsonFileName => "CustomerData.json";
        /// <summary>
        /// Create data from EF Core
        /// </summary>
        public static void CreateJson()
        {
            File.WriteAllText(
                _jsonFileName, 
                JsonConvert.SerializeObject(ToExcel(), 
                    Formatting.Indented));
        }

        /// <summary>
        /// This method is for those w/o access to SQL-Server/EF Core
        /// </summary>
        /// <returns></returns>
        public static List<CustomersForExcel> FromJson() 
            => JsonConvert.DeserializeObject<List<CustomersForExcel>>(File.ReadAllText(_jsonFileName));

        /// <summary>
        /// This method is for importing this data to a new Excel file.
        /// </summary>
        /// <returns>List&lt;<see cref="CustomersForExcel"/>&gt;</returns>
        public static List<CustomersForExcel> ToExcel()
        {
            using var context = new Context();

            return context.Customers
                .Include(customer => customer.Contact)
                .Include(customer => customer.ContactTypeIdentifierNavigation)
                .Include(customer => customer.CountryIdentifierNavigation)
                .Include(customer => customer.Contact.ContactDevices)
                .Select(current => new CustomersForExcel(
                    current.CompanyName, 
                    current.CountryIdentifierNavigation.Name, 
                    current.Contact.ContactTypeIdentifierNavigation.ContactTitle, 
                    $"{current.Contact.FirstName} {current.Contact.LastName}", 
                    current.Phone, current.ModifiedDate, current.CustomerIdentifier))
                .ToList();

        }
    }
}