namespace ForumQuestion.Classes;

public class ArrayHelper
{
    public static void Display(int[] values)
    {
        AnsiConsole.MarkupLine($"[white]Elements are :[/] [[{string.Join(",", values)}]]");
    }
}