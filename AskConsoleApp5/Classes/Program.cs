using System.Runtime.CompilerServices;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace AskConsoleApp5
{
    partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample - select one item";

            W.SetConsoleWindowPosition(W.AnchorWindow.Top | W.AnchorWindow.Left);

        }

    }
}





