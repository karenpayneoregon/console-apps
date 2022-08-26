namespace SqlServerColumnDescriptions.Models;
#nullable disable
public class DatabaseTable
{
    public string DatabaseName { get; set; }
    public string TableName { get; set; }
    public List<Columns> ColumnsList { get; set; }

}