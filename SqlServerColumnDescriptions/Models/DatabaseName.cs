
namespace SqlServerColumnDescriptions.Models;
#nullable disable

internal class DatabaseName
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString() => Name;

}