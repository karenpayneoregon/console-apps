using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace CustomerDatabaseLibraryEntityFramework.Models
{
    public partial class Customer
    {
        public Customer()
        {
            
        }

        public Customer(int identifier)
        {
            Identifier = identifier;
        }
    }
}
