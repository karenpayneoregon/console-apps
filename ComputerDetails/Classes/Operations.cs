#nullable disable

using ComputerDetails.Models;

namespace ComputerDetails.Classes;

public class Operations
{


    public static void Execute(Options options)
    {
        if (options.Basic)
        {
            AnsiConsole.MarkupLine("[yellow]Reading information from your computer[/]");
            var result =  ReadInformation().GetAwaiter().GetResult();
            AnsiConsole.Clear();
            if (result.sucess)
            {
                if (options.Basic && options.Advance)
                {
                    GetBiosInformation(result.details);
                    GetOsHotFixes(result.details);
                }
                else
                {
                    GetBiosInformation(result.details);
                }
            }
            else if (result.exception is not null)
            {
                ExceptionHelpers.ColorStandard(result.exception);
            }
        }
    }

    /// <summary>
    /// Get computer information from PowerShell
    /// </summary>
    private static async Task<(bool sucess, MachineComputerInformation details, Exception exception)> ReadInformation()
    {
        try
        {
            var details = await PowerShellOperations.GetComputerInformationTask();
            return (true, details, null);
        }
        catch (Exception localException)
        {
            return (false, null, localException);
        }
    }

    /// <summary>
    /// Display OS hot fixes ordered by date
    /// </summary>
    /// <param name="details">Details obtained via PowerShell</param>
    private static void GetOsHotFixes(MachineComputerInformation details)
    {
        foreach (var fix in details.OsHotFixes.OrderBy(x => x.InstalledOn))
        {
            Console.WriteLine(fix.HotFixID);
            Console.WriteLine(fix.Description);
            Console.WriteLine(fix.InstalledOn);
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Display BIO information
    /// </summary>
    /// <param name="details">Details obtained via PowerShell</param>
    private static void GetBiosInformation(MachineComputerInformation details)
    {
        var table = new Table()
            .Border(TableBorder.None)
            .AddColumn("[b][u]Setting[/][/]")
            .AddColumn("[b][u]Value[/][/]")
            .Alignment(Justify.Left)
            .BorderColor(Color.LightSlateGrey);

        table.Columns[0].PadRight(5);

        Console.WriteLine(details.WindowsRegisteredOrganization);
        table.AddRow("Organization", details.WindowsRegisteredOrganization);
        Console.WriteLine(details.BiosManufacturer);
        Console.WriteLine(details.BiosReleaseDate);
        Console.WriteLine(details.BiosSeralNumber);
        Console.WriteLine(details.OsArchitecture);
        Console.WriteLine(details.OsName);
        Console.WriteLine(details.OsVersion);
        Console.WriteLine(details.CsModel);
        Console.WriteLine(details.CsUserName);
        Console.WriteLine(details.OsLanguage);
        Console.WriteLine(((details.CsTotalPhysicalMemory / (1024 * 1024 * 1024)) + 1).ToString("###.#GB"));
        Console.WriteLine(Math.Round((double)details.OsFreePhysicalMemory, MidpointRounding.ToPositiveInfinity).ToString("N0"));

        AnsiConsole.Write(table);
    }

}