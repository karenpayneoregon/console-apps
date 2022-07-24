namespace MenuConsoleStudentWorkApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
        public override string ToString() => $"{FirstName,-20}{LastName}";

        public Student() { }

        public Student(int identifier)
        {
            Id = identifier;
        }
    }
}
