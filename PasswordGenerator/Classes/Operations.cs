using CommandLine;
using PasswordGenerator;
using PasswordGeneratorApp.Models;

namespace PasswordGeneratorApp.Classes;

public class Operations
{
    public static void Configuration(string[] args)
    {
        Parser.Default.ParseArguments<Options>(args)
            .WithParsed(options =>
            {
                if (options.Lower)
                {
                    Console.WriteLine("Lower");
                }

                if (options.Upper)
                {
                    Console.WriteLine("Upper");
                }


            });
    }

    public static void Execute(Options options)
    {
        var pwd = new Password();

        if (options.Lower)
        {
            pwd.IncludeLowercase();
        }

        if (options.Upper)
        {
            pwd.IncludeUppercase();
        }

        if (options.Numeric)
        {
            pwd.IncludeNumeric();
        }

        if (options.SpecialCharacters)
        {
            pwd.IncludeSpecial("@_!^#");
        }

        var length = options.Length;

        if (length > 8)
        {
            pwd.LengthRequired(length);
        }

        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[b]Five to choice from[/]");
        Console.WriteLine();
 
        foreach (var password in pwd.NextGroup(5))
        {
            Console.WriteLine($"  {password}");
        }

    }
}