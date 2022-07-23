using System;
using ColonySimulatorApp.LanguageExtension;

namespace ColonySimulatorApp.Models
{
    public class MainMenuOptions
    {
        public MainMenu Id { get; set; }
        public Action Action;
        public override string ToString() => Id.ToString().SplitCamelCase();
    }
}