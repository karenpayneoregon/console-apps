﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace RecordApp.Models
{
    public partial class Contacts
    {
        public Contacts()
        {
            Customers = new HashSet<Customers>();
        }

        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ContactTypeIdentifier { get; set; }

        public virtual ContactType ContactTypeIdentifierNavigation { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
    }
}