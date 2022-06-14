using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityLibrary.LanguageExtensions;
using static System.DateTime;

namespace AskConsoleApp.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public DateTime? BirthDate { get; set; }
        public List<string> FavoriteMonths { get; set; }
        public string Age() => BirthDate == MinValue ? "" : BirthDate?.Age(Now).YearsMonthsDays;

    }
}
