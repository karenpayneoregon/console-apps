using Bogus;
using MenuConsoleStudentWorkApp.Models;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace MenuConsoleStudentWorkApp.Classes
{
    public class BogusOperations
    {
        public static List<Student> Students { get; set; }

        /// <summary>
        /// Generate a list of students
        /// </summary>
        /// <param name="count">how many to generate, five is the default</param>
        /// <returns>List of students with a exit option</returns>
        public static List<Student> GenerateStudents(int count = 5)
        {
            int identifier = 1;

            Faker<Student> prices = new Faker<Student>()
                .CustomInstantiator(f => new Student(identifier++))
                .RuleFor(student => student.FirstName, f => f.Person.FirstName)
                .RuleFor(student => student.LastName, f => f.Person.LastName)
                .RuleFor(student => student.Grade, f => f.Random.Int(1,100));

            List<Student> list = prices.Generate(count);
            list.Add(new Student() {Id = -1, FirstName = "Exit"});
            return list;
        }


    }
}
