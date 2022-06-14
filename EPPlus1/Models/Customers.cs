
using System;

namespace EPPlus1.Models
{
    public partial class Customers
    {
        public Customers()
        {
            
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Contact { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public override string ToString() => CompanyName;

    }
}
