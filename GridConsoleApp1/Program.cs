namespace GridConsoleApp1;

internal partial class Program
{
    static void Main(string[] args)
    {
        foreach (var question in Game.Questions()) 
        {
            Console.Clear();
            var grid = new Grid();

            grid.AddColumn();
            grid.AddColumn();
            
            grid.AddRow(
                new Text("").LeftJustified(),
                new Text(question.First.ToString(), 
                    new Style(Color.Yellow, Color.Black))
                    .RightJustified());

            grid.AddRow(
                new Text(question.Operator, 
                    new Style(Color.White, Color.Black))
                    .LeftJustified(),
                new Text(question.Second.ToString(), 
                    new Style(Color.Yellow, Color.Black))
                    .RightJustified());

            AnsiConsole.Write(grid);

            int answer = GetNumber();
            if (answer == question.Answer)
            {
                Game.Correct += 1;
            }
            else
            {
                Game.Wrong += 1;
            }

            Console.WriteLine("press ENTER to continue");
            Console.ReadLine();
        }

        Console.Clear();
        Console.WriteLine($"Correct {Game.Correct} Wrong {Game.Wrong}");
        Console.WriteLine("press ENTER to exit");
        Console.ReadLine();
    }

    public static int GetNumber() =>
        AnsiConsole.Prompt(
            new TextPrompt<int>("[white]Answer[/]")
                .PromptStyle("cyan")
                .ValidationErrorMessage("[red]Must be number[/]")
        );
}

class Question
{
    public int First { get; set; }
    public int Second { get; set; }
    public string Operator { get; set; }
    public int Answer { get; set; }
}

class Game
{
    // realize these should be random
    public static List<Question> Questions() =>
        new()
        {
            new Question() {First = 100, Second = 5, Operator = "+", Answer = 105},
            new Question() {First = 10, Second = 5, Operator = "+", Answer = 15}
        };

    public static int Correct { get; set; }
    public static int Wrong { get; set; }
}
