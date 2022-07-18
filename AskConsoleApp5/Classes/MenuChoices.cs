using System.Collections.Generic;
using AskConsoleApp5.Models;
using Spectre.Console;

namespace AskConsoleApp5.Classes
{
    public class MenuChoices
    {
        public static List<Language> Languages => new()
        {
            new Language() { Id = 1, Title = "English"},
            new Language() { Id = 2, Title = "Arabic"},
            new Language() { Id = -1, Title = "Leave"}
        };

        public static Language LanguageChoice =>
            AnsiConsole.Prompt(
                new SelectionPrompt<Language>()
                    .Title("[cyan]Select a language or last item to cancel by using up/down arrows then press enter[/]")
                    .AddChoices(MenuChoices.Languages)
                    .HighlightStyle(
                        new Style(
                            Color.White,
                            Color.Black,
                            Decoration.Invert)));
    }
}
