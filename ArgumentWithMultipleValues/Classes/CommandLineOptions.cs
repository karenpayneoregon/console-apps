
using CommandLine;

namespace ArgumentWithMultipleValues.Classes;

public sealed class CommandLineOptions
{
    [Option('m', "modules", Separator = ',', Required = false,HelpText = "List of modules...")]
    public IEnumerable<string> Modules { get; set; }

    // Omitting long name, defaults to name of property, ie "--verbose"
    [Option(Default = false, HelpText = "Prints all messages to standard output.")]
    public bool Verbose { get; set; }


}