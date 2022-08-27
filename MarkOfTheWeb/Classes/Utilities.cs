using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MarkOfTheWeb.Classes
{
    class Utilities
    {
        public static void UnblockFiles(string folderName)
        {
            if (!Directory.Exists(folderName))
            {
                return ;
            }

            var start = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                RedirectStandardOutput = true,
                Arguments = $"Get-ChildItem -Path '{folderName}' -Recurse | Unblock-File",
                CreateNoWindow = true, 
                UseShellExecute = false
            };

            using var process = Process.Start(start);
            process!.WaitForExit();
        }

        //[ModuleInitializer]
        //public static void Init()
        //{
        //    Console.Title = "Remove mark of the web";
        //}
    }
}