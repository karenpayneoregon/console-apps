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

    /// <summary>
    /// Not used, works fine and is quick and actually less trouble than native methods
    /// </summary>
    public static async Task<string> GetAvailableMemoryTask()
    {

        var start = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            RedirectStandardOutput = true,
            Arguments = "(Get-WMIObject Win32_OperatingSystem).FreePhysicalMemory / 1MB",
            CreateNoWindow = true
        };

        using var process = Process.Start(start);
        using var reader = process!.StandardOutput;

        process.EnableRaisingEvents = true;

        var fileContents = await reader.ReadToEndAsync();

        return decimal.TryParse(fileContents, out var value) ? 
            $"{(int)Math.Round(value, 0, MidpointRounding.AwayFromZero)} GB" : 
            "Unknown";

    }
}