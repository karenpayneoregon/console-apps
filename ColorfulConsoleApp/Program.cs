using System;
using System.Collections.Generic;
using System.Drawing;
using Colorful;
using Console = Colorful.Console;
namespace ColorfulConsoleApp
{
    partial class Program
    {
        static void Main(string[] args)
        {

            List<char> chars = new List<char>()
            {
                'r', 'e', 'x', 's', 'z', 'q', 'j', ' ', 't', 'a', 'b', ' ', 'l', 'm',
                'r', 'e', 'x', 's', 'z', 'q', 'j', 'w', 't', 'a', 'b', 'c', 'l', 'm',
                'r', 'e', 'x', 's', 'z', 'q', 'j', 'w', 't', 'a', 'b', 'c', 'l', 'm',
                'r', 'e', 'x', 's', 'z', 'q', 'j', 'w', 't', 'a', 'b', 'c', 'l', 'm'
            };
            Console.WriteWithGradient(chars, Color.Yellow, Color.Fuchsia, 14);
            System.Console.WriteLine();
            Console.WriteFormatted("hi {0} and {1}", Color.DeepSkyBlue, new Formatter("billy", Color.MediumAquamarine), new Formatter("steve", Color.MediumPurple));
            System.Console.WriteLine();
            



            Console.WriteLine("Done", Color.Pink);

            Console.ReadLine();
        }
    }
}
