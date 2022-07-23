using System;
using ColonySimulatorApp.Classes;
using ColonySimulatorApp.Models;
using Spectre.Console;

namespace ColonySimulatorApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                AnsiConsole.Clear();
                MainMenuOptions mainChoice = MenuChoices.MainMenu;
                if (mainChoice.Id == MainMenu.Quit)
                {
                    return;
                }
                else
                {
                    mainChoice.Action();
                    var jobType = MenuChoices.JobTypeMenu;
                    Console.WriteLine(jobType);
                    Console.ReadLine();
                }
            }


        }
    }
}
