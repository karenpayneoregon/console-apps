using System;
using System.CommandLine;
using System.CommandLine.Invocation;

namespace SystemCommandLine.Demo
{
    public class GreetCommand : Command
    {
        private readonly GreetOptions _options;

        public GreetCommand(GreetOptions options)
           : base("greet", "Says a greeting to the specified person.")
        {
            var name = new Option<string>("--name")
            {
                Name = "name",
                Description = "The name of the person to greet.",
                IsRequired = true
            };

            AddOption(name);

            Handler = CommandHandler.Create((string name) => HandleCommand(name));
            _options = options;
        }

        private int HandleCommand(string name)
        {
            try
            {
                Console.WriteLine($"{_options.Greeting} {name}!");
            }
            catch (Exception localException)
            {
                ExceptionHelpers.ColorStandard(localException);
                return 1;
            }

            return 0;
        }
    }
}