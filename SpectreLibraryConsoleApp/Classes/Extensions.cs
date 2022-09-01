using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpectreLibraryConsoleApp.Classes;

public static class Extensions
{
    public static bool IsEven(this int sender) => sender % 2 == 0;
    public static string ToYesNo(this bool value) => value ? "Yes" : "No";
}