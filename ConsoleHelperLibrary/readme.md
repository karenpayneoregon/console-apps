# About

For positioning a console window

> using  W = ConsoleHelperLibrary.Classes.WindowUtility;

...

```csharp
[ModuleInitializer]
public static void Init()
{
    // center this window
    W.SetConsoleWindowPosition(W.AnchorWindow.Center);
}
```

Options

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