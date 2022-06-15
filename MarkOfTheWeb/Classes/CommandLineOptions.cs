using System.Collections.Generic;
using CommandLine;

namespace MarkOfTheWeb.Classes
{
    public sealed class CommandLineOptions
    {
        [Option('d', "dir", Required = true, HelpText = "Directory to remove mark of web")]
        public string Directory { get; set; }


        [Option(Default = false, HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }


    }


}