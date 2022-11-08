using System.Diagnostics;

namespace ColorsApp;

internal partial class Program
{
    public static void Main()
    {
        /////////////////////////////////////////////////////////////////
        // No colors
        /////////////////////////////////////////////////////////////////
        if (AnsiConsole.Profile.Capabilities.ColorSystem == ColorSystem.NoColors)
        {
            AnsiConsole.WriteLine("No colors are supported.");
            Console.ReadLine();
            return;
        }

        //ThreeBitColors();

        //FourBitColors();

        EightBitColors();

        //TwentyFourBitColors();



        Console.ReadLine();
    }

    private static void TwentyFourBitColors()
    {
        /////////////////////////////////////////////////////////////////
        // 24-BIT
        /////////////////////////////////////////////////////////////////
        if (AnsiConsole.Profile.Supports(ColorSystem.TrueColor))
        {
            AnsiConsole.ResetColors();
            AnsiConsole.WriteLine();
            AnsiConsole.Write(new Rule("[yellow bold underline]24-bit Colors[/]").RuleStyle("grey").LeftAligned());
            AnsiConsole.WriteLine();

            AnsiConsole.Write(new ColorBox(width: 80, height: 15));
        }
    }

    private static void EightBitColors()
    {
        /////////////////////////////////////////////////////////////////
        // 8-BIT
        /////////////////////////////////////////////////////////////////
        if (AnsiConsole.Profile.Supports(ColorSystem.EightBit))
        {
            AnsiConsole.ResetColors();
            AnsiConsole.WriteLine();
            AnsiConsole.Write(new Rule("[yellow bold underline]8-bit Colors[/]").RuleStyle("grey").LeftAligned());
            AnsiConsole.WriteLine();

            for (var i = 0; i < 16; i++)
            {

                
                for (var j = 0; j < 16; j++)
                {
                    var number = i * 16 + j;
                   
                    AnsiConsole.Background = Color.FromInt32(number);
                    AnsiConsole.Foreground = AnsiConsole.Background.GetInvertedColor();
                    AnsiConsole.Write($" {number,-4}");
                    AnsiConsole.ResetColors();
                    if ((number + 1) % 16 == 0)
                    {
                        AnsiConsole.WriteLine();
                    }
                }
            }
        }
    }

    private static void FourBitColors()
    {
        /////////////////////////////////////////////////////////////////
        // 4-BIT
        /////////////////////////////////////////////////////////////////
        if (AnsiConsole.Profile.Supports(ColorSystem.Standard))
        {
            AnsiConsole.ResetColors();
            AnsiConsole.WriteLine();
            AnsiConsole.Write(new Rule("[yellow bold underline]4-bit Colors[/]").RuleStyle("grey").LeftAligned());
            AnsiConsole.WriteLine();

            for (var i = 0; i < 16; i++)
            {
                AnsiConsole.Background = Color.FromInt32(i);
                AnsiConsole.Foreground = AnsiConsole.Background.GetInvertedColor();
                AnsiConsole.Write($" {AnsiConsole.Background,-9}");
                AnsiConsole.ResetColors();
                if ((i + 1) % 8 == 0)
                {
                    AnsiConsole.WriteLine();
                }
            }
        }
    }

    private static void ThreeBitColors()
    {
        /////////////////////////////////////////////////////////////////
        // 3-BIT
        /////////////////////////////////////////////////////////////////
        if (AnsiConsole.Profile.Supports(ColorSystem.Legacy))
        {
            AnsiConsole.ResetColors();
            AnsiConsole.WriteLine();
            AnsiConsole.Write(new Rule("[yellow bold underline]3-bit Colors[/]").RuleStyle("grey").LeftAligned());
            AnsiConsole.WriteLine();

            for (var i = 0; i < 8; i++)
            {
                AnsiConsole.Background = Color.FromInt32(i);
                AnsiConsole.Foreground = AnsiConsole.Background.GetInvertedColor();
                AnsiConsole.Write($" {AnsiConsole.Background,-9}");
                AnsiConsole.ResetColors();
                if ((i + 1) % 8 == 0)
                {
                    AnsiConsole.WriteLine();
                }
            }
        }
    }


}