using System;
using System.Threading;
using Spectre.Console;

namespace SimpleSpinner
{
    partial class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.Status()
                .Spinner(Spinner.Known.Aesthetic)
                .Start("Working...", ctx => {
                    Thread.Sleep(2000);

                    ctx.Spinner(Spinner.Known.Aesthetic);
                    // Simulate some work
                    Thread.Sleep(1000);
                    ctx.SpinnerStyle(Style.Parse("cyan"));

                    ctx.Status("Getting there");
                    ctx.Spinner(Spinner.Known.Star);
                    // Simulate some work
                    Thread.Sleep(1000);
                    ctx.SpinnerStyle(Style.Parse("green"));

                    // Simulate some work
                    Thread.Sleep(2000);

                    ctx.Spinner(Spinner.Known.Star);
                    // Simulate some work
                    Thread.Sleep(1000);

                    AnsiConsole.MarkupLine("[b]Finished[/]...");

                });
            Console.ReadLine();
        }
    }
}
