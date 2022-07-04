namespace MenuConsoleAppBasic.Models
{
    public abstract class BaseEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public JobType JobType { get; set; }
        public override string ToString() 
            => $"{FirstName} {LastName}";

    }
}