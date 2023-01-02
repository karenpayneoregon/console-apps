namespace CarsTableConsoleApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            var table = new Table().RoundedBorder()
                .AddColumn("[cyan]Name[/]")
                .AddColumn("[cyan]Miles[/]")
                .AddColumn("[cyan]Year[/]")
                .AddColumn("[cyan]Make[/]")
                .Alignment(Justify.Center)
                .BorderColor(Color.LightSlateGrey)
                .Title("[LightGreen]Cars[/]");

            foreach (var car in Mocked.Cars())
            {
                table.AddRow(car.Name, car.Mileage.ToString(), car.Year.ToString(), car.Make);
            }

            AnsiConsole.Write(table);

            Console.ReadLine();
        }
    }

    public class Car
    {
        public string Name { get; set; }
        public double Mileage { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
    }

    public class Mocked
    {
        public static List<Car> Cars()
        {
            return new List<Car>()
            {
                new Car() { Make = "Make 1", Mileage = 45, Year = 1987, Name = "Car 1"},
                new Car() { Make = "Make 2", Mileage = 15, Year = 2012, Name = "Car 2"},
            };
        }
    }
}