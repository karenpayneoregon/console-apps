using System.Runtime.CompilerServices;


// ReSharper disable once CheckNamespace
namespace GetIntConsoleApp
{
    internal partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            AnsiConsole.MarkupLine("");
            Console.Title = "Code sample";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        }

        /// <summary>
        /// Not used in this code sample
        /// Ask for an int where valid entries are 1 and 2
        /// Using this method allows for no exit other than enter 1 or 2 or close
        /// the application
        /// </summary>
        /// <returns>1 or 2</returns>
        public static int GetInt()
        {
            string errorMessage = "[white on red]Invalid entry! Enter either [b]1[/] or [b]2[/][/]";
            return AnsiConsole.Prompt(
                new TextPrompt<int>("[white]Choose 1 or 2[/]")
                    .PromptStyle("yellow")
                    .DefaultValue(1)
                    .ValidationErrorMessage(errorMessage)
                    .Validate(value => value switch
                    {
                        <= 0 => ValidationResult.Error(errorMessage),
                        >= 2 => ValidationResult.Error(errorMessage),
                        _ => ValidationResult.Success(),
                    }));
        }
    }
}
