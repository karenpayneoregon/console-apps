namespace CenterTextInWindow;

internal partial class Program
{
    static void Main(string[] args)
    {
        ConsoleHelpers.CenterLinesFromTop("Hello world","Enjoy the ride");
        Console.ReadLine();
    }
}

public class ConsoleHelpers
{
    /// <summary>
    /// Center lines horizontally and vertically 
    /// </summary>
    public static void CenterLines(params string[] lines)
    {

        int verticalStart = (Console.WindowHeight - lines.Length) / 2;
        int verticalPosition = verticalStart;

        foreach (var line in lines)
        {
            int horizontalStart = (Console.WindowWidth - line.Length) / 2;
            Console.SetCursorPosition(horizontalStart, verticalPosition);
            Console.Write(line);
            ++verticalPosition;
        }
    }
    /// <summary>
    /// Center lines vertically starting at top of screen
    /// </summary>
    public static void CenterLinesFromTop(params string[] lines)
    {

        int verticalPosition = 0;

        foreach (var line in lines)
        {
            int horizontalStart = (Console.WindowWidth - line.Length) / 2;
            Console.SetCursorPosition(horizontalStart, verticalPosition);
            Console.Write(line);
            ++verticalPosition;
        }
    }
}