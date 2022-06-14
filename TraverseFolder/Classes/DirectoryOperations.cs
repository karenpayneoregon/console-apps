using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            foreach (GroupItem parent in grouped)
            {

                //var rule = new Rule($"[lightsteelblue1]{parent.FolderName}[/]")
                //{
                //    Alignment = Justify.Left,
                //    Style = Style.Parse("navy")
                //};

                //AnsiConsole.Write(rule);

                AnsiConsole.MarkupLine($"[lightsteelblue1]{parent.FolderName}[/]");

                parent.FileList.ForEach(item => Console.WriteLine($"\t{item.Name}"));
            }

            AnsiConsole.WriteLine();
            AnsiConsole.MarkupLine($"[cyan]Finish[/] traversing [cyan][b]{grouped.Count}[/][/] folders");
        }
    }
}

