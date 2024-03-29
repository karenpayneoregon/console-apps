﻿using System.Diagnostics;
using ArgumentWithMultipleValues.Classes;
using CommandLine.Text;

namespace ArgumentWithMultipleValues;

class Program
{
    static void Main(string[] args)
    {
        var title = new HeadingInfo(programName: "Code sample", version: "1.1.1");

        Debug.WriteLine(title);

        CommandLineHelp.ParseArguments(args);

    }
}