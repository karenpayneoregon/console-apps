using GetDirFileCount.Classes;
using Spectre.Console;

namespace GetDirFileCount
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var folderName = Prompts.GetFolderNameAllowNone();
            

            if (string.IsNullOrWhiteSpace(folderName))
            {
                AnsiConsole.MarkupLine("[red]No folder name[/] exiting");
                return;
            }
            else
            {
                if (DirectoryHelpers.FolderExists(folderName))
                {
                    AnsiConsole.MarkupLine($"Please wait, working on [cyan]{folderName}[/]");
                    var (directoryCount, fileCount) = DirectoryHelpers.DirectoryFileCount(folderName, SearchOption.AllDirectories);

                    Console.WriteLine($"Dir count {directoryCount:N0}");
                    Console.WriteLine($"File count {fileCount:N0}");

                }
                else
                {
                    Console.WriteLine($"Folder {folderName} does not exists");
                }
                
            }

        }
    }
}