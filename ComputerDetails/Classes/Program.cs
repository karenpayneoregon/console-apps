﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace ComputerDetails
{
    internal partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "OED Computer information";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        }
    }
}
