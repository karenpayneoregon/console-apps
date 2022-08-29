using PasswordGenerator;
using PasswordGeneratorApp.Classes;

namespace PasswordGeneratorApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {

            AnsiConsole.MarkupLine("[b]Create a random password[/]");
            var length = Prompts.GetInt();
            if (length > 0)
            {
                var pwd = new Password()
                    .IncludeLowercase()
                    .IncludeUppercase()
                    .IncludeNumeric()
                    .IncludeSpecial("@_")
                    .LengthRequired(length);

                for (int index = 0; index < 4; index++)
                {
                    Console.WriteLine(pwd.Next());
                }
            }

 
            Console.ReadLine();
        }
    }
}