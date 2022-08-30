using Cronos;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp1.Classes;

public class WorkerService : BackgroundService
{


    private static readonly string Schedule = CronSchedules.EveryMinute;
    private readonly CronExpression _cron;
    private readonly int _iterations;
    private readonly bool _infinite;

    public WorkerService()
    {
        _cron = CronExpression.Parse(Schedule);
    }

    public WorkerService(int times, bool infinite = true)
    {
        _cron = CronExpression.Parse(Schedule);
        _iterations = times;
        _infinite = infinite;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        int counter = 1;

        while (!stoppingToken.IsCancellationRequested)
        {

            var utcNow = DateTime.UtcNow;
            DateTime? nextUtc = _cron.GetNextOccurrence(utcNow);

            await Task.Delay(nextUtc!.Value - utcNow, stoppingToken);
            await PerformActionAsync(counter);

            counter++;

            if (_infinite) continue;
            if (counter > _iterations)
            {
                Console.WriteLine($"Exiting while on {counter}");
                return;
            }

        }
    }
    /// <summary>
    /// Do nothing method
    /// </summary>
    /// <param name="iteration">which iteration we are on</param>
    private async Task PerformActionAsync(int iteration)
    {
        await Task.Delay(0);
        Console.WriteLine($"{DateTime.Now:hh:mm:ss tt} on iteration {iteration}");
    }

}