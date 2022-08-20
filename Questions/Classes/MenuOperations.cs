using System.Globalization;
using System.Linq;
using Spectre.Console;

namespace Questions.Classes
{
    class MenuOperations
    {

        public static SelectionPrompt<MonthItem> SelectionPrompt()
        {
            var menuItemList = Enumerable.Range(1, 12).Select((index) =>
                new MonthItem(index, DateTimeFormatInfo.CurrentInfo.GetMonthName(index)))
                .ToList();

            menuItemList.Add(new MonthItem(-1, "Exit"));

            SelectionPrompt<MonthItem> menu = new()
            {
                HighlightStyle = new Style(Color.Black, Color.White, Decoration.None)
            };

            menu.Title("[yellow]Select a month[/]");
            menu.PageSize = 14;
            menu.AddChoices(menuItemList);

            return menu;

        }
    }
}
