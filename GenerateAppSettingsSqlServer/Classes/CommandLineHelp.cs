using CommandLine.Text;
using CommandLine;
using GenerateAppSettingsSqlServer.Classes;
using GenerateAppSettingsSqlServer.Models;


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
                helpText.Heading = "[b]Create appsettings for sql-server connections[/]";
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
