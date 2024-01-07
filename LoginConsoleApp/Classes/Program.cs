using System;
using System.Linq;
using System.Runtime.CompilerServices;
using  W = ConsoleHelperLibrary.Classes.WindowUtility;
using LoginConsoleApp.Classes;
using static LoginConsoleApp.Classes.ConsoleHelpers;

// ReSharper disable once CheckNamespace
namespace LoginConsoleApp
{
    partial class Program
    {
        private static void Menu()
        {
            SpectreOperations.DrawHeader();

            var name = SpectreOperations.AskLoginName();
            var password = SpectreOperations.AskPassword();

            var users = Operations.DeserializeUsers();

            var user = users.FirstOrDefault(user => user.Name == name && user.Password == password);

            Console.Clear();

            if (user is null)
            {
                SpectreOperations.DrawGoAwayHeader();
            }
            else
            {
                SpectreOperations.DrawWelcomeHeader();
            }

            ReadLineAsStringTimeout();

        }
        [ModuleInitializer]
        public static void Init()
        {
            // center this window
            W.SetConsoleWindowPosition(W.AnchorWindow.Center);
        }
    }
}
