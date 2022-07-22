# About

## For positioning a console window

> using  W = ConsoleHelperLibrary.Classes.WindowUtility;

...

### Center window

```csharp
[ModuleInitializer]
public static void Init()
{
    // center this window
    W.SetConsoleWindowPosition(W.AnchorWindow.Center);
}
```

### Top left

```csharp
[ModuleInitializer]
public static void Init()
{
    Console.Title = "Code sample - Top left";
    W.SetConsoleWindowPosition(W.AnchorWindow.Top | W.AnchorWindow.Left);
}
```

### Top right

```csharp
[ModuleInitializer]
public static void Init()
{
    Console.Title = "Code sample - Top right";
    W.SetConsoleWindowPosition(W.AnchorWindow.Top | W.AnchorWindow.Right);
}
```

### Bottom right

```csharp
[ModuleInitializer]
public static void Init()
{
    Console.Title = "Code sample - bottom right";
    W.SetConsoleWindowPosition(W.AnchorWindow.Bottom | W.AnchorWindow.Right);
}
```

**Options**

```csharp
public enum AnchorWindow
{
    None = 0x0,
    Top = 0x1,
    Bottom = 0x2,
    Left = 0x4,
    Right = 0x8,
    Center = 0x10,
    Fill = 0x20
}
```

## Disable Min/Max buttons

> using M = ConsoleHelperLibrary.Classes.ConsoleMenu;

...

```csharp
M.DisableMinMaxButtons();
```

## ReadLine timeout

> using static ConsoleHelperLibrary.Classes.KeysHelper;

...

```csharp
ReadLineTimed("bye");
```

##  Center text in a window

The method `CenterLines` take a string array where each element is written to a new line.

```csharp
using System;
using System.Runtime.CompilerServices;
using W = ConsoleHelperLibrary.Classes.WindowUtility;
using D = ConsoleHelperLibrary.Classes.WriteUtility;

namespace SmallWindowApp
{
    partial class Program
    {
        [ModuleInitializer]
        public static void Init()
        {
            W.SetConsoleWindowPosition(W.AnchorWindow.Center);
            D.CenterLines("Small", "Window");
            Console.CursorVisible = false;
        }
    }
}
```