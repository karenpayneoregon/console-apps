# About

Forum question

C# program to display an array of integer values in the console window
https://stackoverflow.com/questions/75122603/c-sharp-program-to-display-an-array-of-integer-values-in-the-console-window

Many coders just starting out don't read the documentation and/or consider things like, what if an number is expected but a string is entered. This is what this project does, starts with a bad set of code, moved to a better way than even a better way.

The current code is recommended.

```csharp
using System;

namespace Array {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter the size of the array:");
            int size = int.Parse(Console.ReadLine());
            int[] inputArray = new int[size];
            Console.WriteLine("Enter " + size + " elements for the Array");
            for (int i = 0; i < inputArray.Length; i++) {
                inputArray[i] = int.Parse(Console.ReadLine());
            }
            PrintArray printArray = new PrintArray();
            printArray.PutArray(inputArray);
        }
    }
    public class PrintArray {
        public void PutArray(int[] Array) {
            Console.WriteLine("Elements are :");
            Console.Write("[");
            for (int i = 0; i < Array.Length; i++) {
                Console.Write(Array[i]);
                if (i != Array.Length - 1) {
                    Console.Write(", ");
                }
            }
            Console.WriteLine("]");
        }
    }
}
```

Solution without external libraries

```csharp
internal partial class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the size of the array:");

        if (int.TryParse(Console.ReadLine(), out var size))
        {
            int[] inputArray = new int[size];
            Console.WriteLine($"Enter {size} elements for the Array");

            for (int index = 0; index < inputArray.Length; index++)
            {
                Console.WriteLine($"Enter value for {index}");
                if (int.TryParse(Console.ReadLine(), out var value))
                {
                    inputArray[index] = value;
                }
                else
                {
                    Console.WriteLine($"{index} value will be 0");
                }
            }

            Console.Clear();
            ArrayHelper.Display(inputArray);
        }
        else
        {
            Console.WriteLine("Invalid value for size");
        }

        Console.ReadLine();
    }
}
public class ArrayHelper
{
    public static void Display(int[] values)
    {
        Console.WriteLine($"Elements are : [{string.Join(",", values)}]");
    }
}
```

Solution using Spectre.Console

```csharp
internal partial class Program
{
    static void Main(string[] args)
    {

        int size = Prompts.GetInt("Enter the size of the array:");
        if (size > 0)
        {
            int[] inputArray = new int[size];

            for (int index = 0; index < inputArray.Length; index++)
            {
                inputArray[index] = Prompts.GetInt($"Enter value for {index}");
            }

            Console.Clear();
            ArrayHelper.Display(inputArray);
        }
        else
        {
            AnsiConsole.MarkupLine("[white on red]Invalid value for size, press enter to exit[/]");
        }

        Console.WriteLine();
        AnsiConsole.MarkupLine("[white on blue]Press enter to exit[/]");
        Console.ReadLine();
    }
}
public class ArrayHelper
{
    public static void Display(int[] values)
    {
        AnsiConsole.MarkupLine($"[white]Elements are :[/] [[{string.Join(",", values)}]]");
    }
}
public class Prompts
{
    public static int GetInt(string title) =>
        AnsiConsole.Prompt(
            new TextPrompt<int>($"[cyan]{title}[/]")
                .PromptStyle("yellow")
                .DefaultValue(0)
                .DefaultValueStyle(new Style(Color.Fuchsia, Color.Black, Decoration.None)));
}
```