using ColonySimulatorApp.LanguageExtension;

namespace ColonySimulatorApp.Models
{
    public class JobTypeMenuOptions
    {
        public JobType Id { get; set; }
        public override string ToString() => Id.ToString().SplitCamelCase();
    }
}