namespace GetIntConsoleApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            var (success, entryValue) = GetResponse();
            Console.Clear();
            if (success)
            {
                AnsiConsole.MarkupLine($"You selected [white on blue]{entryValue}[/], press a key to exit");
            }
            else
            {
                AnsiConsole.MarkupLine("[b]Aborted[/], press a key to exit");
            }

            Console.ReadLine();
        }

        private static (bool sucess, int? result) GetResponse()
        {

            while (true)
            {
                Console.Clear();
                var entryValue = GetNumber();
                if (entryValue is 1 or 2)
                {
                    return (true, entryValue);
                }
                else
                {
                    Console.Clear();
                    var ask = AnsiConsole.Confirm("[red]Invalid entry, try again?[/]");
                    if (!ask)
                    {
                        return (false, null);
                    }
                }
            }
        }

        /// <summary>
        /// Ask for 1 or 2, only int values are permitted
        /// </summary>
        /// <returns></returns>
        internal static int GetNumber()
        {
            return AnsiConsole.Prompt(
                new TextPrompt<int>("[white on blue]Choose 1 or 2[/]")
                    .PromptStyle("white")
                    .DefaultValueStyle(new Style(Color.Yellow))
                    .DefaultValue(0)
                    .ValidationErrorMessage(
                        "[white on red]Invalid entry! Enter either [b]1[/] or [b]2[/][/]"));
        }
    }
}