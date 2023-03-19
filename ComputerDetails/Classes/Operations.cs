#nullable disable

using ComputerDetails.Models;

namespace ComputerDetails.Classes;

public class Operations
{
    public static void Execute(Options options)
    {
        
        if (options.Basic || options.Advance)
        {
            AnsiConsole.MarkupLine("[yellow]Reading information from your computer[/]");

            var result =  ReadInformation().GetAwaiter().GetResult();
            AnsiConsole.Clear();
            if (result.sucess)
            {
                if (options.Basic && options.Advance)
                {
                    BasicInformation(result.details);
                    GetOsHotFixes(result.details);
                }
                else
                {
                    BasicInformation(result.details);
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
            
            MachineComputerInformation details = await PowerShellOperations.GetComputerInformationTask();

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
        Console.WriteLine();

        var table = new Table()
            .Border(TableBorder.None)
            .AddColumn("[b][u]Fix id[/][/]")
            .AddColumn("[b][u]Date[/][/]")
            .AddColumn("[b][u]Description[/][/]")
            .Alignment(Justify.Left)
            .BorderColor(Color.LightSlateGrey);

        table.Columns[0].PadRight(5);

        foreach (var fix in details.OsHotFixes.OrderBy(x => x.InstalledOn))
        {
            table.AddRow(fix.HotFixID, fix.InstalledOn.ToShortDateString(),
                fix.Description.Contains("Security Update", StringComparison.OrdinalIgnoreCase)
                    ? $"[magenta3_1]{fix.Description}[/]"
                    : fix.Description);
        }

        Console.WriteLine();
        AnsiConsole.MarkupLine("[b]Hot fixes[/]");
        AnsiConsole.Write(table);
    }

    /// <summary>
    /// Display BIO information
    /// </summary>
    /// <param name="details">Details obtained via PowerShell</param>
    private static void BasicInformation(MachineComputerInformation details)
    {
        var table = new Table()
            .Border(TableBorder.None)
            .AddColumn("[b][u]Setting[/][/]")
            .AddColumn("[b][u]Value[/][/]")
            .Alignment(Justify.Left)
            .BorderColor(Color.LightSlateGrey);

        table.Columns[0].PadRight(5);

        table.AddRow("Organization", details.WindowsRegisteredOrganization);
        table.AddRow("Bios Manufacturer", details.BiosManufacturer);
        table.AddRow("Service tag", $"[black on white]{details.BiosSeralNumber}[/]");
        table.AddRow("Login user", details.CsUserName);

        //Console.WriteLine(((details.CsTotalPhysicalMemory / (1024 * 1024 * 1024)) + 1).ToString("###.#GB"));
        //Console.WriteLine(details.BiosReleaseDate);
        //Console.WriteLine(details.OsArchitecture);
        //Console.WriteLine(details.OsName);
        //Console.WriteLine(details.OsVersion);
        //Console.WriteLine(details.CsModel);
        //Console.WriteLine(details.CsUserName);
        //Console.WriteLine(details.OsLanguage);
        //Console.WriteLine(Math.Round((double)details.OsFreePhysicalMemory, MidpointRounding.ToPositiveInfinity).ToString("N0"));

        AnsiConsole.Write(table);
    }

}