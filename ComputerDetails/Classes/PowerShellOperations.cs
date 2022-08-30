using System.Diagnostics;
using ComputerDetails.Models;
using Newtonsoft.Json;

namespace ComputerDetails.Classes;

internal class PowerShellOperations
{
    public static async Task<MachineComputerInformation> GetComputerInformationTask()
    {

        string fileName = "computerInformation.json";

        if (Directory.Exists("C:\\OED"))
        {
            fileName = Path.Combine("C:\\OED", fileName);
        }

        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        var start = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            RedirectStandardOutput = true,
            Arguments = "Get-ComputerInfo | ConvertTo-Json",
            CreateNoWindow = true
        };

        using var process = Process.Start(start);
        using var reader = process!.StandardOutput;

        process.EnableRaisingEvents = true;

        var fileContents = await reader.ReadToEndAsync();

        await File.WriteAllTextAsync(fileName, fileContents);
        await process.WaitForExitAsync();

        var json = await File.ReadAllTextAsync(fileName);

        if (File.Exists(fileName))
        {
            File.Delete(fileName);

        }

        return JsonConvert.DeserializeObject<MachineComputerInformation>(json);

    }
}