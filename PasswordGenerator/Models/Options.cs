using CommandLine;

namespace PasswordGeneratorApp.Models;

public class Options
{
    [Option('l', "lower", Required = false, HelpText = "Include [cyan]lowercase[/]")]
    public bool Lower { get; set; }

    [Option('u', "upper", Required = false, HelpText = "Include [cyan]uppercase[/]")]
    public bool Upper { get; set; }

    [Option('n', "numeric", Required = false, HelpText = "Include [cyan]numeric[/]")]
    public bool Numeric { get; set; }

    [Option('s', "special", Required = false, HelpText = "Include [cyan]special chars[/]")]
    public bool SpecialCharacters { get; set; }

    [Option('x', "length", Required = false, HelpText = "password [cyan]length[/]")]
    public int Length { get; set; }
}