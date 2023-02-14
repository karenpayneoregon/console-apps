using System.Diagnostics;
using CommandLine;
using CommandLine.Text;

namespace ArgumentWithMultipleValues.Classes;

public class CommandLineHelp
{
    /// <summary>
    /// For displaying help with a command argument of --help or -help (which invokes I don't know -h)
    /// </summary>
    public static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errs)
    {

        var help = HelpText.AutoBuild(result, helpText =>
        {
            helpText.AdditionalNewLineAfterOption = false;
            helpText.Heading = "Fictitious utility";
            helpText.Copyright = $"Copyright (c) {DateTime.Now.Year} Some company";

            return HelpText.DefaultParsingErrorsHandler(result, helpText);

        }, e => e);

        Debug.WriteLine(help);
        Environment.Exit(-1);
    }

    /// <summary>
    /// Parse command line for expected arguments
    /// </summary>
    /// <param name="args">incoming program arguments</param>
    public static void ParseArguments(string[] args)
    {
        Parser parser = new CommandLine.Parser(with => with.HelpWriter = null);

        ParserResult<CommandLineOptions> results = parser.ParseArguments<CommandLineOptions>(args);

        results.WithParsed<CommandLineOptions>(Operations.RunWork).WithNotParsed(errors =>
            DisplayHelp(results, errors));

    }
}