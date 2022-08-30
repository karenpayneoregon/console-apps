using System.Diagnostics;
using ComputerDetails.Models;
using Newtonsoft.Json;

namespace ComputerDetails.Classes;

internal class PowerShellOperations
{
    public static async Task<MachineComputerInformation> GetComputerInformationTask()
    {

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

        return JsonConvert.DeserializeObject<MachineComputerInformation>(fileContents);

    }
}