#nullable disable
using CommandLine;

namespace CommandLineParserDefaultVerb.Verbs;

/// <summary>
/// This is a default verb
///
/// You can pass say -f xxxxxx or by default we can pass -f xxxxx
/// 
/// </summary>
[Verb("say", true, HelpText = "say hello")]
public class DefaultVerbOption
{
    [Option('f', "hello", Required = true)]
    public string FirstName { get; set; }
}