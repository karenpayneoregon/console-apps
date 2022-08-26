using System;
using CommandLine;

namespace myage.Classes
{
    public sealed class CommandLineOptions
    {
        [Option('f', "from", Required = true, HelpText = "From date")]
        public DateTime From { get; set; }

        [Option('t', "to", Required = false, HelpText = "To date")]
        public DateTime To { get; set; }

        [Option(Default = false, HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }

    }
}