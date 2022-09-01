#nullable disable

namespace SpectreLibraryConsoleApp.Models;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString() => Name;

    public Company(int id)
    {
        Id = id;
    }

    public Company()
    {
            
    }
}