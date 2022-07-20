# Spectre.Console helpers

The Markup class allows you to output rich text to the console. If there is a need to show output without style look at use UtilityLibrary.LanguageExtensions.StripCodes to remove styling from a string.

For example see SpectreUnitTestProject.

```csharp
[TestMethod]
[TestTraits(Trait.SpectreConsole)]
public void StripCodesTest()
{
    // arrange
    string expected = "File size: 1234";
    int length = 1234;
    string input = $"[red on yellow]File size:[/] [bold]\t{length,-10}[/]";

    // act
    var output = input.StripCodes();

    // assert
    Check.That(expected).Equals(output);
}
```