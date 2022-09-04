using CommandLine;

namespace GenerateAppSettingsSqlServer.Models;

public class Options
{
    [Option('f', "folder", Required = true, HelpText = "appsettings.json path")]
    public string Folder { get; set; }

    /// <summary>
    /// Indicate to create a connection string with Encrypt=True
    /// </summary>
    /// <remarks>
    /// Had this as a bool but had some freaky things happened thus using a string
    /// </remarks>
    [Option('u', "useencryption", Required = true, HelpText = "use encrypt")]
    public string UseEncryption { get; set; }

}