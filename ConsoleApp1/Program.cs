using ConsoleApp1.Classes;
using Spectre.Console;


namespace ConsoleApp1;

/// <summary>
/// Tinkering
/// </summary>
partial class Program
{
    // does nada 
    private static readonly CancellationTokenSource CancellationTokenSource = new();
    static async Task Main(string[] args)
    {

        try
        {
            await WorkerExample();
        }
        finally
        {
            CancellationTokenSource.Dispose();
        }

        Header();
        Console.ReadLine();
    }

    private static async Task WorkerExample()
    {
        var service = new WorkerService(times: 2, infinite: false);
        await service.StartAsync(CancellationTokenSource.Token);
    }

}