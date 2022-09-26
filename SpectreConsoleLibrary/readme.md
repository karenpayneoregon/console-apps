# About

Provides easy to use common prompts.

## Included

| Name        |   Description    |   Comments |
|:------------- |:-------------|:-------------|
| GetFirstName | prompt for first name | Allows no input which returns an empty string |
| GetMiddleName | prompt for first name | Allows no input which returns an empty string |
| GetLastName | prompt for last name | Allows no input which returns an empty string |
| GetInt | prompts for an int |  |
| GetDecimal | prompts for a decimal |  |
| GetDouble | prompts for a double |  |
| GetBirthDate | prompts for a birth date  |  |
| GetDateTime | prompts for a regular DateTime |  |
| GetDateOnly | prompts for a nullable DateOnly | accepts a start value or has a default value |
| GetTimeOnly | prompts for a nullable TimeOnly | accepts a start value or has a default value |
| GetBool | prompts for Yes or No | returns a bool |
| GetUserName | prompt for user name  | suitable for a login |
| GetPassword | prompt for a password masked | suitable for a login |
| GetNewPassword | prompts for a new password | has default rules which can be changed see [package repo](https://github.com/havardt/PasswordValidator) |
| AskConfirmation | Ask a question  | returns a bool |
| MonthsSelection | presents a list of months | allows single or mulitple selections |
| GenericSelectionList&lt;T&gt; | Present a list where the user can select one or more items |  |
|  |  |  |


```csharp
using SpectreConsoleLibrary;
using SpectreLibraryConsoleApp.Classes;
using static System.DateTime;

namespace SpectreLibraryConsoleApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {

            Console.ReadLine();
        }

        private static void GenericSelectionListExample()
        {
            var companies = Prompts.GenericSelectionList(BogusOperations.Companies(), 10, "Select");
            if (companies.Any())
            {
                var table = new Table()
                    .RoundedBorder()
                    .AddColumn("[b]Id[/]")
                    .AddColumn("[b]Name[/]")
                    .Alignment(Justify.Left)
                    .BorderColor(Color.LightSlateGrey)
                    .Title("[LightGreen]Choices[/]");

                foreach (var company in companies)
                {
                    table.AddRow(company.Id.ToString(), company.Name);
                }

                AnsiConsole.Write(table);
            }
            else
            {
                Console.WriteLine("No companies selected");
            }
        }

        private static void GetInoutExamples()
        {
            var password = Prompts.GetNewPassword("Enter a new password");
            Console.WriteLine(password);


            TimeOnly? only = Prompts.GetTimeOnly($"{Now:HH}:00");
            if (only is not null)
            {
                Console.WriteLine(only);
            }
            else
            {
                Console.WriteLine("Null");
            }

            DateOnly? dateOnly = Prompts.GetDateOnly(Now.ToString("yyyy-MM-dd"));
            if (dateOnly is not null)
            {
                Console.WriteLine(dateOnly.Value.ToString("MM/dd/yyyy"));
            }
            else
            {
                Console.WriteLine("Null");
            }


            if (Prompts.GetBool("Question"))
            {
                Console.WriteLine("T");
            }
            else
            {
                Console.WriteLine("F");
            }

            if (Prompt.GetYesNo("Question", true))
            {
                Console.WriteLine("T");
            }
            else
            {
                Console.WriteLine("F");
            }
        }
    }
}
```

