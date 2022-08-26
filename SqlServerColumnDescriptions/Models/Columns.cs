
namespace SqlServerColumnDescriptions.Models;
#nullable disable
public class Columns
{
    public string Name { get; set; }
    public string Description { get; set; }
    public override string ToString() => Name;

}