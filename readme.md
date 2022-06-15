# Learn how to work with Console project user interfaces

*Console applications are back in vogue, hosting everything from input-focused command-line apps, worker services, and ASP.NET Core. As we all use current and future target frameworks, the upgraded console experience is the glow-up story of .NET.*

[Khalid Abuhakmeh](https://twitter.com/buhakmeh)

---

What place do console applications have today? 

First and foremost, provides a place to learn how to program in this case C# language without worrying about learning how to connect basic coding like learning to work with strings, dates with a user interface.

For helper utilities with a simple user interface which can be with user input, or no user interface with parameters sent to the application or read from a configuration file.

Another use as mentioned above, worker services and ASP.NET Core.

Other than projects located under the Basics folder use enhanced user interfaces provided by Spectre.Console NuGet package and Terminal.Gui which provides mouse support.

Both Spectre.Console and Terminal.Gui provide examples for using their libraries although in many cases they are not simple examples which is where these code samples are helpful, broken down, easy to run.

- In several projects EF Core is used and for those projects require a script to run to create SQL-Server databases along with populating tables first.
- Other than one project, Program class is setup as partial with startup code under the Classes folder for each project.
- Most projects are centered on screen or full screen using code in ConsoleHelperLibrary

Hope for those just starting out with coding using Console projects find these code samples helpful.

![Tree](assets/tree.png)

![Data Table Group](assets/dataTableGroup.png)

![Chart](assets/chart.png)


In the following screen the autor of the library does not show events, mine does.

![Gui](assets/gui.png)

## Solution structure

Solution folders are used to separate various third party libraries used to work with user interfaces for console projects.

## Spectre.console issues

This library has about 100 issues/bugs/feature request, even so knowing them you can still create useful console applications

- [Resizing Tables and Panels #356](https://github.com/spectreconsole/spectre.console/discussions/356) discussion on inability to refresh tables and panels with 

## Resources

- ASP.NET Core Web API Project [From Scratch](https://dotnettutorials.net/lesson/build-asp-net-core-web-api-project/) (using a console project)
- [Configure](https://www.programmingwithwolfgang.com/configure-dependency-injection-for-net-5-console-applications/) Dependency Injection for .NET 5 Console Applications
- Microsoft Make [HTTP requests](https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient) in a .NET console app using C#
- [Building a Useful](https://www.codeproject.com/Articles/816301/Csharp-Building-a-Useful-Extensible-NET-Console-Ap), Extensible .NET Console Application Template for Development and Testing
- [Hiding the Console Window of the .NET/C# Console Application](https://jamilhallal.blogspot.com/2022/02/hiding-the-console-window-of-the-dotnet-console-application.html)
- [Cross-platform](https://opensource.com/article/17/5/cross-platform-console-apps) console apps with .NET Core

## Other libraries to check out

- [Terminal.Gui](https://github.com/migueldeicaza/gui.cs) Console-based user interface toolkit for .NET applications.
- [ShellProgressBar](https://github.com/Mpdreamz/shellprogressbar) display progress in your console application
- [Colorful.Console](https://github.com/tomakita/Colorful.Console) Style your .NET console output!
- [Devlead.Console.Template](https://www.devlead.se/posts/2021/2021-01-15-my-preferred-console-stack) this is considered advance console app coding