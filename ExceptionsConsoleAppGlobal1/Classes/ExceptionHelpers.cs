using Spectre.Console;

namespace ExceptionsConsoleAppGlobal1.Classes;

/// <summary>
/// Custom setting for presenting runtime exceptions using AnsiConsole.WriteException.
///
/// The idea here is to present different types of exceptions with different colors while
/// one would be for all exceptions and the other(s) for specific exception types.
/// </summary>
public static class ExceptionHelpers
{
    public static void ColorWithCyanFuchsia(this Exception exception)
    {
        AnsiConsole.WriteException(exception: exception, settings: new ExceptionSettings
        {
            Format = ExceptionFormats.ShortenEverything | ExceptionFormats.ShowLinks,
            Style = new ExceptionStyle
            {
                Exception = new Style().Foreground(color: Color.Grey),
                Message = new Style().Foreground(color: Color.DarkSeaGreen),
                NonEmphasized = new Style().Foreground(color: Color.Cornsilk1),
                Parenthesis = new Style().Foreground(color: Color.Cornsilk1),
                Method = new Style().Foreground(color: Color.Fuchsia),
                ParameterName = new Style().Foreground(color: Color.Cornsilk1),
                ParameterType = new Style().Foreground(color: Color.Aqua),
                Path = new Style().Foreground(color: Color.Red),
                LineNumber = new Style().Foreground(color: Color.Cornsilk1),
            }
        });

    }
    public static void ColorStandard(this Exception exception)
    {
        AnsiConsole.WriteException(exception: exception, settings: new ExceptionSettings
        {
            Format = ExceptionFormats.ShortenEverything | ExceptionFormats.ShowLinks,
            Style = new ExceptionStyle
            {
                Exception = new Style().Foreground(color: Color.Grey),
                Message = new Style().Foreground(color: Color.White),
                NonEmphasized = new Style().Foreground(color: Color.Cornsilk1),
                Parenthesis = new Style().Foreground(color: Color.GreenYellow),
                Method = new Style().Foreground(color: Color.DarkOrange),
                ParameterName = new Style().Foreground(color: Color.Cornsilk1),
                ParameterType = new Style().Foreground(color: Color.Aqua),
                Path = new Style().Foreground(color: Color.White),
                LineNumber = new Style().Foreground(color: Color.Cornsilk1),
            }
        });

    }
}