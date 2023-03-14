using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace ComputerDetails
{
    internal partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Computer information";
            WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
        }
    }
}
