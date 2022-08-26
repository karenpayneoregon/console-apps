namespace SqlServerColumnDescriptions.Models;

public class DatabaseTable
{
    public string DatabaseName { get; set; }
    public string TableName { get; set; }
    public List<Columns> ColumnsList { get; set; }

}