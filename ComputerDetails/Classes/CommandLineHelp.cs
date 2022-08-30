using CommandLine.Text;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerDetails.Models;

namespace ComputerDetails.Classes
{
    public class CommandLineHelp
    {
        /// <summary>
        /// For displaying help with a command argument of --help 
        /// </summary>
        public static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errs)
        {

            var help = HelpText.AutoBuild(result, helpText =>
            {
                helpText.AdditionalNewLineAfterOption = false;
                helpText.Heading = "[greenyellow]Password generator[/]";
                helpText.Copyright = $"Copyright (c) {DateTime.Now.Year} Karen Payne";


                return HelpText.DefaultParsingErrorsHandler(result, helpText);

            }, e => e);

            AnsiConsole.MarkupLine(help);

        }

        /// <summary>
        /// Parse command line
        /// </summary>
        /// <param name="args">incoming program arguments</param>
        public static void ParseArguments(string[] args)
        {
            Parser parser = new Parser(with => with.HelpWriter = null);

            ParserResult<Options> results = parser.ParseArguments<Options>(args);


            results.WithParsed(Operations.Execute).WithNotParsed(errors => DisplayHelp(results, errors));


        }
    }
}
