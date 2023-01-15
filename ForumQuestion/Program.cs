using ForumQuestion.Classes;

namespace ForumQuestion;

internal partial class Program
{
    static void Main(string[] args)
    {

        int size = Prompts.GetInt("Enter the size of the array:");
        if (size > 0)
        {
            int[] inputArray = new int[size];

            for (int index = 0; index < inputArray.Length; index++)
            {
                inputArray[index] = Prompts.GetInt($"Enter value for {index}");
            }

            Console.Clear();
            ArrayHelper.Display(inputArray);
        }
        else
        {
            AnsiConsole.MarkupLine("[white on red]Invalid value for size, press enter to exit[/]");
        }

        Console.WriteLine();
        AnsiConsole.MarkupLine("[white on blue]Press enter to exit[/]");
        Console.ReadLine();
    }
}