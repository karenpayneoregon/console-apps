﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable

namespace DependencyInjectionSimple.Models;

public partial class Products
{
    public Products()
    {
        OrderDetails = new HashSet<OrderDetails>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public virtual ICollection<OrderDetails> OrderDetails { get; set; }
}