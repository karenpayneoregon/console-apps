using System.Collections.Generic;
using BarChartConsoleApp.Models;
using Spectre.Console;

namespace BarChartConsoleApp.Classes
{
    public class SportsSurvey
    {
        public static List<SportItem> List => new()
        {
            new() { Name = "Soccer", Color = Color.Yellow, Count = 58 },
            new() { Name = "Golf", Color = Color.Green, Count = 21 },
            new() { Name = "Baseball", Color = Color.White, Count = 79 },
            new() { Name = "Ice Hockey", Color = Color.Red, Count = 39 },
        };
    }
}