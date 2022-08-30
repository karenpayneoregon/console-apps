#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ComputerDetails.Classes;

internal class Utilities
{
    private static void VpnInformation()
    {
        if (!NetworkInterface.GetIsNetworkAvailable()) return;

        NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

        foreach (NetworkInterface @interface in interfaces)
        {
            if (@interface.OperationalStatus == OperationalStatus.Up)
            {
                if ((@interface.NetworkInterfaceType == NetworkInterfaceType.Ppp) && (@interface.NetworkInterfaceType != NetworkInterfaceType.Loopback))
                {
                    //IPv4InterfaceStatistics statistics = @interface.GetIPv4Statistics();
                    Console.WriteLine(@interface.Name + " " + @interface.NetworkInterfaceType.ToString() + " " + @interface.Description);
                }
                else
                {
                    Console.WriteLine($"VPN Connection is lost! [{@interface.Name}]");
                }
            }
        }
    }

    /// <summary>
    /// Determine if user's home drive/folder is available.
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// Better safe to wrap things with a try/catch in the exception of a permission exception
    ///
    /// HOMEDRIVE/HOMEPATH is where the user's personal files are: downloads, music, documents, etc.
    /// HOMESHARE is used instead of HOMEDRIVE if the home directory uses UNC paths.
    /// </remarks>
    public static (bool success, Exception exception) HomeDriveAvailable()
    {
        try
        {
            return Environment.GetEnvironmentVariables().Contains("HOMESHARE")
                ? (Directory.Exists(Environment.GetEnvironmentVariable("HOMESHARE")), null)
                : (false, null);
        }
        catch (Exception localException)
        {
            return (false, localException);
        }
    }
}