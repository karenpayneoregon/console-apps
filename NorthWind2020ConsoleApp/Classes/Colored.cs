using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using Colorful;
using ConsoleHelperLibrary.Classes;
using Console = Colorful.Console;

namespace NorthWind2020ConsoleApp.Classes
{
    public class Colored
    {
        [ModuleInitializer]
        public static void InitColored()
        {

            Console.WriteLine("Reading employee information", Color.Pink);

        }

        public static void ShowMessage(string text)
        {
            Console.WriteLine(text, Color.Pink);
        }
    }
}
