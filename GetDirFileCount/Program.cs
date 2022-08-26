using GetDirFileCount.Classes;
using Spectre.Console;

namespace GetDirFileCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var folderName = @"C:\OED\Dotnetland"; // Prompts.GetFolderNameAllowNone();
            //var folderName = Prompts.GetFolderNameAllowNone();
            Console.WriteLine(folderName);
            if (string.IsNullOrWhiteSpace(folderName))
            {
                AnsiConsole.MarkupLine("[red]No folder name[/] exiting");
                return;
            }
            else
            {
                if (DirectoryHelpers.FolderExists(folderName))
                {
                    var (directoryCount, fileCount) = DirectoryHelpers.DirectoryFileCount(folderName, SearchOption.AllDirectories);

                    Console.WriteLine($"Dir count {directoryCount:N0}");
                    Console.WriteLine($"File count {fileCount:N0}");

                }
                
            }
            Console.ReadLine();
        }
    }
}