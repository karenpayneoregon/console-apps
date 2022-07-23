using System.Collections.Generic;
using ColonySimulatorApp.Models;
using Spectre.Console;

namespace ColonySimulatorApp.Classes
{
    public class MenuChoices
    {
        public static List<MainMenuOptions> MainChoices() => new()
        {
            new MainMenuOptions() { Id = Models.MainMenu.NextDay, Action = GameOperations.Next},
            new MainMenuOptions() { Id = Models.MainMenu.Build, Action = GameOperations.Build},
            new MainMenuOptions() { Id = Models.MainMenu.Jobs, Action = GameOperations.Job},
            new MainMenuOptions() { Id = Models.MainMenu.Quit}
        };

        public static List<JobTypeMenuOptions> JobTypesChoices() =>new()
            {
                new JobTypeMenuOptions() { Id = JobType.Farmer },
                new JobTypeMenuOptions() { Id = JobType.LumberJack },
                new JobTypeMenuOptions() { Id = JobType.Miner},
                new JobTypeMenuOptions() { Id = JobType.Quit}
            };

        public static List<UpDownChoices> UpDownChoices() => new()
        {
            new UpDownChoices() { Id = UpDown.Plus  },
            new UpDownChoices() { Id = UpDown.Minus }
        };

        public static MainMenuOptions MainMenu =>
            AnsiConsole.Prompt(
                new SelectionPrompt<MainMenuOptions>()
                    .Title("[cyan]Select a option or last item to cancel by using up/down arrows then press enter[/]")
                    .AddChoices(MainChoices())
                    .HighlightStyle(
                        new Style(
                            Color.White,
                            Color.Black,
                            Decoration.Invert)));

        public static JobTypeMenuOptions JobTypeMenu =>
            AnsiConsole.Prompt(
                new SelectionPrompt<JobTypeMenuOptions>()
                    .Title("[cyan]Select a option or last item to cancel by using up/down arrows then press enter[/]")
                    .AddChoices(JobTypesChoices())
                    .HighlightStyle(
                        new Style(
                            Color.White,
                            Color.Black,
                            Decoration.Invert)));

        public static UpDownChoices UpDownMenu =>
            AnsiConsole.Prompt(
                new SelectionPrompt<UpDownChoices>()
                    .Title("[cyan]Select a option or last item to cancel by using up/down arrows then press enter[/]")
                    .AddChoices(UpDownChoices())
                    .HighlightStyle(
                        new Style(
                            Color.White,
                            Color.Black,
                            Decoration.Invert)));
    }
}
