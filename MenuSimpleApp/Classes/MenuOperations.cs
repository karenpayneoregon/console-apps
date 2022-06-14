using System.Text;
using System.Threading.Tasks;
using Spectre.Console;

namespace MenuSimpleApp.Classes
{
    public class MenuOperations
    {
        /// <summary>
        /// Create the menu for showing months along with specifying colors,
        /// page size (how menu items to show w/o scrolling)
        /// </summary>
        /// <returns></returns>
        public static SelectionPrompt<MenuItem> SelectionPrompt()
        {
            SelectionPrompt<MenuItem> menu = new()
            {
                HighlightStyle = new Style(Color.Black, Color.White, Decoration.None)
            };

            menu.Title("Select a [B]category[/]");
            menu.PageSize = 14;
            menu.MoreChoicesText("[grey](Move up and down to reveal more categories)[/]");
            menu.AddChoices(MockOperations.GetMenuItems());
            
            return menu;

        }
    }
}
