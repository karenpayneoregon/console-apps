/*
 * here there is no distinction between the main function and others, some
 * developers like this, not me.
 */

using System;
using System.Drawing;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using static System.Console;


for (int index = 1; index < 4; index++)
{
    WriteLine($"Passing {index} gives {GetValue(index)}");
}



ReadLine();



static string GetValue(int value) 
    => 0 switch
    {
        _ when value == 1 => "Hello",
        _ when value == 2 => "World",
        _ => "NaN"
    };

#region Helper classes

/// <summary>
/// This class could also be in a separate class file
/// </summary>
internal static class Operations
{
    public static string GetValue(int value)
        => 0 switch
        {
            _ when value == 1 => "Hello",
            _ when value == 2 => "World",
            _ => "NaN"
        };
}

#endregion

