using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerDatabaseLibraryEntityFramework.Data;
using CustomerDatabaseLibraryEntityFramework.Models;

using Microsoft.EntityFrameworkCore;

namespace CustomerDatabaseLibraryEntityFramework.Classes
{
    public class DataOperations
    {
        /// <summary>
        /// Read all records in the gender table
        /// </summary>
        public static IReadOnlyList<Genders> GendersList(bool addSelect = true)
        {
            using var context = new CustomerContext();
            var list = context.Genders.ToList();

            if (addSelect)
            {
                list.Insert(0, new Genders() { id = -1, GenderType = "Select" });
            }

            return list.ToImmutableList();
        }

        /// <summary>
        /// Read all Contact types in the database
        /// </summary>
        public static IReadOnlyList<ContactTypes> ContactTypesList(bool addSelect = true)
        {
            using var context = new CustomerContext();
            var list = context.ContactTypes.ToList();

            if (addSelect)
            {
                list.Insert(0, new ContactTypes() { Identifier = -1, ContactType = "Select" });
            }

            return list.ToImmutableList();
        }

        /// <summary>
        /// Read all Customers in the database
        /// </summary>
        public static List<Customer> Customers()
        {
            using var context = new CustomerContext();
            return context.Customer.ToList();
        }

        /// <summary>
        /// Get a Customer by primary key
        /// </summary>
        /// <param name="identifier">Primary key</param>
        /// <returns>Found Customer or null</returns>
        public static Customer CustomerByIdentifier(int identifier)
        {
            using var context = new CustomerContext();
            return context.Customer.FirstOrDefault(customer => customer.Identifier == identifier);
        }

        /// <summary>
        /// Add new customer, on save new primary key is set
        /// </summary>
        /// <param name="customer">New customer</param>
        public static void AddNewCustomer(Customer customer)
        {

            using CustomerContext context = new();

            context.Add(customer);
            context.SaveChanges();
        }

        /// <summary>
        /// Add more than one Customer to the database table
        /// </summary>
        /// <param name="list">List of valid customers</param>
        public static void AddCustomers(List<Customer> list)
        {
            using CustomerContext context = new();

            context.AddRange(list);
            context.SaveChanges();

        }

        /// <summary>
        /// Remove an known existing record
        /// </summary>
        /// <param name="customer">Existing customer</param>
        /// <returns></returns>
        public static bool RemoveCustomer(Customer customer)
        {
            using CustomerContext context = new();
            context.Remove(customer);
            return context.SaveChanges() == 1;
        }

        /// <summary>
        /// Edit an existing customer, note since we are disconnected
        /// from the DbContext the customer came from we must tell
        /// the current DbContext that the customer state is modified.
        /// </summary>
        /// <param name="customer">Existing customer</param>
        /// <returns>Success</returns>
        public static bool EditCustomer(Customer customer)
        {
            using CustomerContext context = new();
            context.Entry(customer).State = EntityState.Modified;
            return context.SaveChanges() == 1;
        }


    }
}
