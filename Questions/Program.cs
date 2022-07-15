using System;
using System.Collections.Generic;
using System.Linq;

namespace Questions
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var text = "Hello";

            var characters = text.ToCharArray();
            foreach (var character in characters)
            {
                Console.WriteLine(character); // add to ListBox
            }

            Console.WriteLine();

            List<string> datalist = new();
            datalist.AddRange(text.Select(character => character.ToString()));

            foreach (var item in datalist)
            {
                Console.WriteLine(item); // add to ListBo
            }

            Console.ReadLine();
        }
    }
}
