using ColonySimulatorApp.LanguageExtension;

namespace ColonySimulatorApp.Models
{
    public class UpDownChoices
    {
        public UpDown Id { get; set; }
        public override string ToString() => Id.ToString().SplitCamelCase();
    }
}