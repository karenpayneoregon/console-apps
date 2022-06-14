using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Cli;
using TraverseFolder.Classes;
using TraverseFolder.Commands;
using TraverseFolder.Models;

namespace TraverseFolder
{
    partial class Program
    {

        static int Main(string[] commandLineArgs)
        {

            var app = new CommandApp();
            app.Configure(config =>
            {
                config.ValidateExamples();

                config.AddCommand<ListCommand>("list");
            });

            return app.Run(commandLineArgs);

        }
    }
}
