﻿using System.Globalization;
using AskConsoleApp5.Models;
using Spectre.Console;

namespace AskConsoleApp5.Classes
{
    public class MenuChoices
    {

        public static List<Language> Languages()
        {
            var languages = CultureInfo.GetCultures(CultureTypes.AllCultures & ~CultureTypes.NeutralCultures)
                .Select((ci,id) => new Language()
                {
                    Id = id, 
                    Title = ci.DisplayName, Code = ci.Name
                } )
                .ToList();

            languages.RemoveAt(0);
            languages.Add(new Language() { Id = -1, Title = "Exit" });

            foreach (var language in languages)
            {
                language.Title = Markup.Escape(language.Title);
            }

            return languages;
        }

        public static Language LanguageChoice =>
            AnsiConsole.Prompt(
                new SelectionPrompt<Language>()
                    .Title("[cyan]Select a language or last item to cancel by using up/down arrows then press enter[/]")
                    .AddChoices(MenuChoices.Languages())
                    .HighlightStyle(
                        new Style(
                            Color.White,
                            Color.Black,
                            Decoration.Invert)));
    }
}
