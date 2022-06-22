using AskConsoleApp2.Models;

namespace AskConsoleApp2.Classes
{
    public class Configuration
    {
        public static UserChoices Get()
        {
            UserChoices choices = new UserChoices
            {
                PasswordLength = Prompts.PasswordLength()
            };

            var options = Prompts.Choices();

            if (options.Count <= 0) return choices;

            choices.UseNumbers = options.Contains("Numbers");
            choices.UseOtherSigns = options.Contains("Other signs?");
            choices.UseNumbers = options.Contains("Numbers?");
            choices.UseUppercaseLetters = options.Contains("Uppercase letters?");

            return choices;
        }
    }
}
