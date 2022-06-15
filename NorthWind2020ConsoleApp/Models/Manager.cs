using System.Collections.Generic;

namespace NorthWind2020ConsoleApp.Models
{
    public class Manager
    {
        public Employees Employee { get; set; }
        public List<Employees> Workers { get; set; } = new();
    }
}