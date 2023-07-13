using System.Runtime.CompilerServices;
using DependencyInjectionSimple.LanguageExtensions;

// ReSharper disable once CheckNamespace
namespace DependencyInjectionSimple;

internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = $"{nameof(DependencyInjectionSimple).SplitCamelCase()} Code sample";
        W.SetConsoleWindowPosition(W.AnchorWindow.Center);
    }
   
}