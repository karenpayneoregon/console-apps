using System;
using System.Threading.Tasks;
using Spectre.Console;

namespace LoopWaitForSpecificKeys
{
    partial class Program
    {
        static void Main(string[] args)
        {
            
            AnsiConsole.MarkupLine("[cyan]Loop[/] until pressing [b]Y[/] or [b]N[/]");
            Loop();
            
            Console.WriteLine("Out");
            Console.ReadLine();
        }

        static void Loop()
        {
            while (!(Console.KeyAvailable))
            {

                switch (Console.ReadKey(true))
                {
                    case { Key: ConsoleKey.Y }: 
                        Console.WriteLine("Y pressed"); 
                        return;
                    case { Key: ConsoleKey.N }: 
                        Console.WriteLine("N pressed");
                        return;
                }
            }
        }

        static void Ticker()
        {
            Console.SetCursorPosition(0,1);
            Console.WriteLine($"{DateTime.Now:hh:mm:ss t z}");
        }
    }
}
