using CommandLine;

namespace ComputerDetails.Models;

public class Options
{
    [Option('b', "basic", Required = true, HelpText = "basic information")]
    public bool Basic { get; set; }

    [Option('a', "advance", Required = false, HelpText = "advance information")]
    public bool Advance { get; set; }

}