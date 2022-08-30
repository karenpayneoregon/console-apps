#nullable disable

using System.Reflection;
using CommandLine;
using CommandLineParserDefaultVerb.Verbs;

namespace CommandLineParserDefaultVerb;

internal class Program
{
    static void Main(string[] args)
    {
        var types = LoadVerbs();

        Parser.Default.ParseArguments(args, types)
            .WithParsed(Run)
            .WithNotParsed(HandleErrors);

        Console.ReadLine();
    }

    private static void HandleErrors(IEnumerable<Error> sender)
    {
        foreach (var error in sender)
        {
            Console.WriteLine(error.Tag);
        }
    }

    //load all types using Reflection
    private static Type[] LoadVerbs() 
        => Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetCustomAttribute<VerbAttribute>() != null).ToArray();

    private static void Run(object sender)
    {
        switch (sender)
        {
            case CommitOptions o:
                break;
            case AddPerson a:
                break;
            case DefaultVerbOption v:
                Console.WriteLine($"Hello {v.FirstName}");
                break;
        }
    }

}