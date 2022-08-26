using System.Diagnostics;

namespace ArgumentWithMultipleValues.Classes;

public class Operations
{
    /// <summary>
    /// Dummy work for the application
    /// </summary>
    /// <param name="options"><see cref="CommandLineOptions"/></param>
    public static void RunWork(CommandLineOptions options)
    {
        foreach (var module in options.Modules)
        {
            Debug.WriteLine($"'{module}'"); // change to Console.WriteLine for a dotnet tool
        }
    }
}