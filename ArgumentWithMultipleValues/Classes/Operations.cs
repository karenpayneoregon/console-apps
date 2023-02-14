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
        Debug.WriteLine("Arguments");
        foreach (var module in options.Modules)
        {
            
            if (module.Equals("item three", StringComparison.OrdinalIgnoreCase) )
            {
                Debug.WriteLine($"\t\t\"{module}\""); // change to Console.WriteLine for a dotnet tool
            }
            else
            {
                Debug.WriteLine($"\t\"{module}\""); // change to Console.WriteLine for a dotnet tool
            }
            
        }
    }
}