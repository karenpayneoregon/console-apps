using ConsoleApp1.Classes;


namespace ConsoleApp1;

/// <summary>
/// Tinkering
/// </summary>
internal class Program
{
    // does nada 
    private static readonly CancellationTokenSource CancellationTokenSource = new();
    static async Task Main(string[] args)
    {

        await Task.Delay(0);

        try
        {
            await WorkerExample();
        }
        finally
        {
            CancellationTokenSource.Dispose();
        }

        Console.WriteLine("xxx");

        // needed
        Console.ReadLine();
    }

    private static async Task WorkerExample()
    {
        var service = new WorkerService(2);
        await service.StartAsync(CancellationTokenSource.Token);
    }
}