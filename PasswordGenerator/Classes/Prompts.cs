using static System.Globalization.DateTimeFormatInfo;

namespace PasswordGeneratorApp.Classes;

public class Prompts
{

    public static int GetInt() 
        => AnsiConsole.Prompt(new TextPrompt<int>("[yellow]Enter Length of password[/]").PromptStyle("cyan").DefaultValue(8));

}