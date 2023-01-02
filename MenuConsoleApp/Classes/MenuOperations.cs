using MenuConsoleApp.Models;
using Spectre.Console;

namespace MenuConsoleApp.Classes;

public class MenuOperations
{
    /// <summary>
    /// Display main menu
    /// </summary>
    /// <returns>Prompt of <see cref="Categories"/></returns>
    public static SelectionPrompt<Categories> CategoryMenu()
    {
        SelectionPrompt<Categories> menu = new()
        {
            HighlightStyle = new Style(Color.Cyan1, Color.Black, Decoration.None)
        };

        menu.Title("Select a [B]category[/]");
        menu.MoreChoicesText("[grey](Move up and down to reveal more categories)[/]");
        menu.AddChoices(DataOperations.CategoriesArray());

        return menu;
    }

    /// <summary>
    /// Sets title and highlight color of prompt
    /// </summary>
    /// <returns><see cref="Spectre.Console.SelectionPrompt"/></returns>
    public static SelectionPrompt<Categories> ConfigureCategorySelectionPrompt()
    {
        SelectionPrompt<Categories> selection = new SelectionPrompt<Categories>()
            .Title("Select[b] [white]category[/][/] to show products");

        selection.HighlightStyle = new Style(
            Color.Cyan1, 
            Color.Black, 
            Decoration.None);

        return selection;
    }

    /// <summary>
    /// Product menu list
    /// </summary>
    /// <param name="productContinue">used to terminate menu</param>
    /// <param name="category">Filter products by category identifier</param>
    public static Products ProductMenu(Categories category)
    {
        Products product = null;
        bool productContinue = true;

        while (productContinue)
        {

            SelectionPrompt<Products> menu = new()
            {
                HighlightStyle = new Style(Color.Aqua, Color.Red, Decoration.None)
            };

            menu.Title("Select a [B]Product[/]");
            menu.PageSize = 15;
            menu.MoreChoicesText("[grey](Move up and down to reveal more categories)[/]");
            menu.AddChoices(DataOperations.ProductListFromJson(category.CategoryId));

            product = AnsiConsole.Prompt(menu);

            if (product.ProductId == -1)
            {
                productContinue = false;
            }
            else
            {
                AskConfirmation(product);
                productContinue = false;
            }

        }

        return product!;
    }

    public static void AskConfirmation(Products products)
    {
        if (AnsiConsole.Confirm($"Select [B]{products.ProductName}[/]?"))
        {
            // TODO
        }
        else
        {
            // TODO
        }

    }

    /// <summary>
    /// Product menu list
    /// </summary>
    /// <param name="categoryIdentifier">Filter products by category identifier</param>

    public static void ShowRecords(int categoryIdentifier)
    {
        var table = new Table()
            .RoundedBorder()
            .AddColumn("[b]Id[/]")
            .AddColumn("[b]Name[/]")
            .AddColumn("[b]Supplier[/]")
            .Alignment(Justify.Center)
            .BorderColor(Color.LightSlateGrey)
            .Title("[yellow]Products[/]");


        var products = DataOperations.ProductListFromJson(categoryIdentifier);

        foreach (var product in products)
        {
            int supplierId = product.SupplierId ?? -1;

            table.AddRow(product.ProductId.ToString(), product.ProductName, supplierId.ToString());
        }

        AnsiConsole.Write(table);

    }
}