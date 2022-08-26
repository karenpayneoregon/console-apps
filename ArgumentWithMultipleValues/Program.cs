using System.Diagnostics;
using ArgumentWithMultipleValues.Classes;
using CommandLine.Text;

namespace ArgumentWithMultipleValues;

class Program
{
    static void Main(string[] args)
    {
        var title = new HeadingInfo(programName: "My super Modules", version: "1.1.1");
        Debug.WriteLine(title); // change to Console.WriteLine for a dotnet tool
        CommandLineHelp.ParseArguments(args);
    }
}