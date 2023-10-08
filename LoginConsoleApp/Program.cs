using System;
using LoginConsoleApp.Classes;


namespace LoginConsoleApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Operations.SerializeUsers();


            if (Operations.FileCheck())
            {
                Menu();
            }
            else
            {
                SpectreOperations.CanNotContinueHeader();
                Console.WriteLine("Contact support, press any key to terminate");
                Console.ReadLine();
            }
           
        }


    }
}
