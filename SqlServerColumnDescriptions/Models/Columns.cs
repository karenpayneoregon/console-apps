using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerColumnDescriptions.Models
{
    public class Columns
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public override string ToString() => Name;

    }
}
