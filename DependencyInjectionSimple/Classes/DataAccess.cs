using DependencyInjectionSimple.Data;

namespace DependencyInjectionSimple.Classes;

public class DataAccess
{
    private readonly PizzaContext _context;

    public DataAccess(PizzaContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Simple read example, logging is disabled in appsettings.json for EF Core
    ///
    /// "Microsoft.EntityFrameworkCore": "None"
    /// 
    /// </summary>
    public async Task Execute(string[] args)
    {

        var customers = await _context.Customers
            .Include(c => c.Orders)
            .ToListAsync();

        Console.WriteLine();

        foreach (var customer in customers)
        {
            AnsiConsole.MarkupLine($"[cyan]{customer}[/][yellow]{customer.Orders.Count,3}[/]");
        }

        Console.WriteLine();
        await Task.CompletedTask;
    }
    
}