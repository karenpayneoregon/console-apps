namespace ForumQuestion.Classes;

public class Prompts
{
    public static int GetInt(string title) =>
        AnsiConsole.Prompt(
            new TextPrompt<int>($"[cyan]{title}[/]")
                .PromptStyle("yellow")
                .DefaultValue(0)
                .DefaultValueStyle(new Style(Color.Fuchsia, Color.Black, Decoration.None)));
}