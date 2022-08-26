using Spectre.Console;
using SqlServerColumnDescriptions.Classes;
using SqlServerColumnDescriptions.Models;

namespace SqlServerColumnDescriptions
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "";
            Worker.Execute();

        }
    }
}