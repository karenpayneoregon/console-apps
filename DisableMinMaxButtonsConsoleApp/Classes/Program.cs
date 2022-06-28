using System;
using System.Runtime.CompilerServices;
using Spectre.Console;
using W = ConsoleHelperLibrary.Classes.WindowUtility;
using M = ConsoleHelperLibrary.Classes.ConsoleMenu;

// ReSharper disable once CheckNamespace
namespace DisableMinMaxButtonsConsoleApp
{
    partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample: disable min/max buttons";

            M.DisableMinMaxButtons();
            W.SetConsoleWindowPosition(W.AnchorWindow.Center);

            var grid = new Grid()
                .AddColumn(new GridColumn()
                    .NoWrap()
                    .PadLeft(10)
                    .PadRight(10))
                .AddRow("[b]Example[/] for showing how to disable [b]min[/] and [b]max[/] buttons. " + 
                        "Buttons are visible, and not [u]grayed[/] out.").Centered()
                .Centered();

            AnsiConsole.Write(new Panel(grid).Header("Information"));

        }

    }
}





