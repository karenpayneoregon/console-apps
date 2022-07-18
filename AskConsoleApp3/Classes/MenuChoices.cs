using System.Collections.Generic;
using AskConsoleApp3.Models;

namespace AskConsoleApp3.Classes
{
    public class MenuChoices
    {
        public static List<Route> Routes => new()
        {
            new Route() { Id = 1, Title = "First"},
            new Route() { Id = 2, Title = "Second"},
            new Route() { Id = 3, Title = "Never mind I changed my mind"}
        };
    }
}
