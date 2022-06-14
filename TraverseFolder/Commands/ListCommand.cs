using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Cli;
using TraverseFolder.Classes;

namespace TraverseFolder.Commands
{
    /// <summary>
    /// Important, List is the command not ListCommand so if we
    /// had a class named GetDataCommand the command is GetData.
    ///
    /// Note the path is variable here although the file extensions are
    /// hardwired as the idea is for the app to always get .png and .ico.
    ///
    /// By adding another property of type array we can pass in one or more
    /// file extensions rather than being hardwired as this is now.
    /// </summary>
    public class ListCommand : Command<ListCommand.Settings>
    {
        public class Settings : CommandSettings
        {
            /// <summary>
            /// Top level folder to traverse all sub-folders
            /// </summary>
            [CommandOption("-d|--dir")]
            [Description("Example to list .ico and .png")]
            public string DirectoryName { get; set; }
        }

        /// <summary>
        /// Is executed/called when the app runs e.g.
        ///    return app.Run(commandLineArgs);
        /// in Program.Main
        /// </summary>
        public override int Execute(CommandContext context, Settings settings)
        {
            AnsiConsole.MarkupLine($"[bold yellow]{settings.DirectoryName}[/]");
            DirectoryOperations.ListFolderContent(settings.DirectoryName);
            Console.ReadLine(); // remove for command line tool
            return 0;
        }
        
    }
}
