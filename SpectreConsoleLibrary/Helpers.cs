namespace SpectreConsoleLibrary;

public class Helpers
{
    /// <summary>
    /// Get length of an int
    /// </summary>
    /// <param name="sender">int value to get length for</param>
    /// <returns>length of int</returns>
    public static int IntLength(int sender) =>
        sender switch
        {
            < 0 => 0,
            0 => 1,
            _ => (int)Math.Floor(Math.Log10(sender)) + 1
        };
}