namespace ConsoleApp1.Classes;

public static class Extensions
{
    public static async Task SafeDelay(this Task source)
    {
        try
        {
            await source;
        }
        catch (TaskCanceledException)
        {
            // I don't want a throw on TaskCanceledException...
        }
    }
}