using SpectreConsoleLibrary;
using static System.DateTime;

namespace SpectreLibraryConsoleApp
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            //var password = Prompts.GetNewPassword("Enter a new password");
            //Console.WriteLine(password);


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




            Console.ReadLine();

        }
    }
}