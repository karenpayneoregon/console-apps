using System;
using System.Runtime.CompilerServices;
using Terminal.Gui;
using W = ConsoleHelperLibrary.Classes.WindowUtility;

// ReSharper disable once CheckNamespace
namespace TopMenuConsoleApp
{
    partial class Program
    {
        /// <summary>
        /// Provide application title and center application window
        /// </summary>
        [ModuleInitializer]
        public static void Init()
        {
            Console.Title = "Code sample";
            W.SetConsoleWindowPosition(W.AnchorWindow.Center);
        }

        /// <summary>
        /// Create new <see cref="Window"/>, size and position
        /// </summary>
        private static Window CreateWindow()
        {
            var applicationLoginWindow = new Window("Login!!!")
            {
                X = Pos.Center(),
                Y = 5, 
                Width = Dim.Percent(50),
                Height = 17
            };

            
            return applicationLoginWindow;

        }

        /// <summary>
        /// Create menu-bar
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        private static MenuBar CreateMenuBar(Toplevel top)
        {
            static bool Quit()
            {
                var n = MessageBox.Query(50, 7, "Quit Demo", "Are you sure you want to quit this demo?", "Yes", "No");
                return n == 0;
            }

            // Creates a menu bar, the item "New" has a help menu.
            var menu = new MenuBar(new MenuBarItem[]
            {
                new("_File", new[]
                {
                    new MenuItem("_Quit", "", () =>
                    {
                        if (Quit()) top.Running = false;
                    })
                })
            });

            return menu;
        }

        /// <summary>
        /// Create controls to collect input and respond to input
        /// </summary>
        private static Label CreateControls(
            out Label password, 
            out TextField loginText, 
            out TextField passText, 
            out Button loginButton,
            out Button cancelButton)
        {
            var login = new Label("Login: ") { X = 3, Y = 2 };
            password = new Label("Password: ")
            {
                X = Pos.Left(login),
                Y = Pos.Top(login) + 1
            };

            loginText = new TextField("")
            {
                X = Pos.Right(password),
                Y = Pos.Top(login),
                Width = 40
            };

            passText = new TextField("")
            {
                Secret = true,
                X = Pos.Left(loginText),
                Y = Pos.Top(password),
                Width = Dim.Width(loginText)
            };

            loginButton = new Button("Login", true)
            {
                X = Pos.Left(passText),
                Y = Pos.Top(passText) + 2
            };

            cancelButton = new Button("Cancel", true)
            {
                X = Pos.Left(password) + 22,
                Y = Pos.Top(password) + 2
            };

            return login;
        }

        /// <summary>
        /// Here we create one event to get user name and password
        /// </summary>
        private static void CreateEvents(Button loginButton, TextField loginText, TextField passText, Button cancelButton, Toplevel top)
        {
            static bool Quit()
            {
                var n = MessageBox.Query(50, 7, "Quit Demo", "Are you sure you want to quit this demo?", "Yes", "No");
                return n == 0;
            }

            loginButton.Clicked += delegate
            {
                if (!string.IsNullOrWhiteSpace(loginText.Text.ToString()) && !string.IsNullOrWhiteSpace(passText.Text.ToString()))
                {
                    MessageBox.Query(25, 8, "Info", $"Name: {loginText.Text} password: {passText.Text}", "Ok");
                    DummyDoSomethingOnValidLogin();
                }
                else
                {
                    MessageBox.ErrorQuery(25, 8, "Error", "Need user name and password.", "Ok");
                }
            };

            cancelButton.Clicked += delegate
            {
                if (Quit()) top.Running = false;
            };
        }

        private static void DummyDoSomethingOnValidLogin()
        {
            // place logic here for main program code
        }
    }
}





