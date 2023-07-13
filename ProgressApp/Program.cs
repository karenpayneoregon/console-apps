using Spectre.Console;

namespace ProgressApp;

partial class Program
{
    static async Task Main(string[] args)
    {

        await AnsiConsole.Progress().StartAsync(async ctx =>
        {

            var gettingReadyTask = ctx.AddTask("[cyan]Getting things ready[/]");
                
            while (!ctx.IsFinished)
            {

                await Task.Delay(300);
                gettingReadyTask.Increment(10.5);

            }
        });

        Console.ReadLine();
    }
}