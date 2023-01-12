using static System.DateTime;
namespace Layout1App;

internal partial class Program
{
    static void Main(string[] args)
    {


        // Create the layout
        var layout = new Layout("Root")
            .SplitColumns(
                new Layout("Left"),
                new Layout("Right")
                    .SplitRows(
                        new Layout("Top"),
                        new Layout("Bottom")));

        layout["Left"].Update(new FigletText("Hello World").Color(Color.Yellow));
        layout["Top"].Update(ThisMonth());
        layout["Bottom"].Update(NextMonth());
        
        

        AnsiConsole.Write(layout);
        ExitPrompt();

    }
    private static Calendar ThisMonth()
    {
        var currentMonth = new Calendar(Now.Year, Now.Month);
        currentMonth.AddCalendarEvent(currentMonth.Year, currentMonth.Month, 5);
        currentMonth.AddCalendarEvent(currentMonth.Year, currentMonth.Month, 12);
        currentMonth.AddCalendarEvent(currentMonth.Year, currentMonth.Month, 20);
        currentMonth.AddCalendarEvent(currentMonth.Year, currentMonth.Month, 11);
        currentMonth.AddCalendarEvent(currentMonth.Year, currentMonth.Month, 18);
        currentMonth.HighlightStyle(Style.Parse("cyan bold"));
        currentMonth.HeaderStyle(Style.Parse("red"));
        currentMonth.ShowHeader();
        currentMonth.Alignment(Justify.Center);
        return currentMonth;
    }
    private static Calendar NextMonth()
    {
        var nextMonth = new Calendar(Now.Year, Now.Month + 1);
        nextMonth.AddCalendarEvent(nextMonth.Year, nextMonth.Month, 20);
        nextMonth.HighlightStyle(Style.Parse("yellow bold"));
        nextMonth.ShowHeader();
        nextMonth.HeaderStyle(Style.Parse("cyan"));
        nextMonth.Alignment(Justify.Center);
        return nextMonth;
    }
}