using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Spectre.Console;
using TraverseFolder.Models;

namespace TraverseFolder.Classes
{
    public class DirectoryOperations
    {
        /// <summary>
        /// Find files in folder
        /// </summary>
        /// <param name="path">Folder to iterate</param>
        /// <param name="allowedExtensions">extensions to find</param>
        /// <returns></returns>
        public static  List<string> EnumerateFolders(string path, string[] allowedExtensions)
            => Directory
                .EnumerateFiles(path,"", SearchOption.AllDirectories)
                .Where(file => allowedExtensions.Any(file.ToLower().EndsWith))
                .ToList();

        public static void ListFolderContent(string folderName)
        {

            if (!Directory.Exists(folderName))
            {
                AnsiConsole.MarkupLine($"[red]Directory does not exists[/]");
                Console.WriteLine(folderName);
                return;
            }

            string[] allowedExtensions = { ".png", ".ico" };  // TODO

            List<string> list = EnumerateFolders(folderName, allowedExtensions);
            List<GroupItem> grouped = list.Select(item =>
                    new Item(
                        Path.GetDirectoryName(item),
                        Path.GetFileName(item)))
                .ToList()
                .GroupBy(item => item.Folder)
                .Select(groupItem => new GroupItem(
                    groupItem.Key,
                    groupItem.ToList()))
                .ToList();

            //WriteToFile(grouped);

            foreach (GroupItem parent in grouped)
            {

                AnsiConsole.MarkupLine($"[lightsteelblue1]{parent.FolderName}[/]");

                parent.FileList.ForEach(item => Console.WriteLine($"\t{item.Name}"));
            }

            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine($"[cyan]Finish[/] traversing [cyan][b]{grouped.Count}[/][/] folders");
        }

        /// <summary>
        /// File results to a file
        /// * Before enabling, change the path and file name
        /// </summary>
        /// <param name="grouped"></param>
        private static void WriteToFile(List<GroupItem> grouped)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(grouped, options);
            File.WriteAllText("C:\\OED\\Files.json", jsonString);
        }
    }
}

