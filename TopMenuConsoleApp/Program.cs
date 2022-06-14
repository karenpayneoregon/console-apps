using System;
using Terminal.Gui;
using NStack;

namespace TopMenuConsoleApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Application.Init();
            
            var top = Application.Top;
            
            var loginWindow = CreateWindow();
            top.Add(loginWindow);

            var menu = CreateMenuBar(top);
            top.Add(menu);


            // create controls
            var loginLabel = CreateControls(
                out var password, 
                out var loginTextField, 
                out var passTextField, 
                out var loginButton, 
                out var cancelButton);


            CreateEvents(
                loginButton, 
                loginTextField, 
                passTextField, 
                cancelButton, 
                top);

            loginWindow.Add(loginLabel, password, loginTextField, passTextField, cancelButton, loginButton,
                new Label(3, 8, "Press F9 activate the menu-bar")
            );

            
            Application.Run();

            Application.Shutdown();
 
        }


    }

}
