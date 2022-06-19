using System;

namespace BasicConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadLine();
        }

        private static void Wrong()
        {
            int input = 0;
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                //code here
            }

            Console.WriteLine(input);
        }

        private static void Right()
        {
            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out var input))
            {
                Console.WriteLine($"Value from ReadLine: {input}");
            }
            else
            {
                Console.WriteLine($"'{userInput}' can not represent a int");
            }
        }
    }
}
