namespace MenuConsoleApp.Classes;

public class NumberHelpers
{
    public static double GetRandomDouble(double minimum, double maximum)
        => Math.Truncate(100 * new Random().NextDouble() * (maximum - minimum) + minimum) / 100;

    public static int GetRandomInt(int minimum, int maximum)
        => new Random().Next(minimum, maximum);
}