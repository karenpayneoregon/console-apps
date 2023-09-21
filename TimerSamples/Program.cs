using ThreadingTimerApp.Classes;

namespace ThreadingTimerApp
{
    internal partial class Program
    {
        static Task Main(string[] args)
        {
            
            TimerHelper.Message += OnMessageReceived;
            TimerHelper.Start();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Started, press ENTER to stop");
            Console.ResetColor();
            Console.ReadLine();
            TimerHelper.Stop();
            return Task.CompletedTask;
        }
        private static void OnMessageReceived(string message)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }
    }
}