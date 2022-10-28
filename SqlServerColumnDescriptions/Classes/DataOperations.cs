using Microsoft.Data.SqlClient;
using System.Data;
using SqlServerColumnDescriptions.Models;

namespace SqlServerColumnDescriptions.Classes;

internal class DataOperations
{
    public static string Server { get; set; } = ".\\SQLEXPRESS";

    public static List<DatabaseName> DatabaseNames()
    {
        List<DatabaseName> list = new();
        int identifier = 1;
        using var cn = new SqlConnection($"Data Source={Server};Initial Catalog=master;integrated security=True;Encrypt=False");
        using var cmd = new SqlCommand { Connection = cn, CommandText = SqlStatements.GetDatabaseNames};
        cn.Open();
        using var reader =  cmd.ExecuteReader();

        while (reader.Read())
        {
            list.Add(new DatabaseName() {Name = reader.GetString(0), Id = identifier});
            identifier++;
        }

        list.Add(new DatabaseName() {Id = -1, Name = "Exit"});
        return list;
    }

    public static (List<DatabaseTable> list, Exception exception) GetDetails(string databaseName)
    {
        List<DatabaseTable> list = new ();

        try
        {
            using var cn = new SqlConnection($"Data Source={Server};Initial Catalog={databaseName};integrated security=True;Encrypt=False");
            using var cmd = new SqlCommand { Connection = cn, CommandText = SqlStatements.GetTableNames(databaseName) };
            cn.Open();
            using var reader = cmd.ExecuteReader();


            List<string> names = new List<string>();
            while (reader.Read())
            {
                names.Add(reader.GetString(0).Replace("dbo.", ""));
            }


            return (GetDescriptions(databaseName, names),null)!;
        }
        catch (Exception exception)
        {

            return (list, exception);
        }
    }

    /// <summary>
    /// Get column descriptions for a table
    /// </summary>
    /// <param name="databaseName">catalog</param>
    /// <param name="tableNames">table names in catalog</param>
    /// <remarks>
    /// Being optimistic that we can dispense with exception handling since we just open the connection in the calling procedure
    /// </remarks>
    public static List<DatabaseTable> GetDescriptions(string databaseName,List<string> tableNames)
    {
        List<DatabaseTable> list = new();
        using var cn = new SqlConnection($"Data Source={Server};Initial Catalog={databaseName};integrated security=True;Encrypt=False");
        using var cmd = new SqlCommand { Connection = cn, CommandText = SqlStatements.Descriptions() };
        cmd.Parameters.Add("@TableName", SqlDbType.NChar);
        cn.Open();

        foreach (var tableName in tableNames)
        {
                
            cmd.Parameters["@TableName"].Value = tableName;

            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                DatabaseTable item = new() {DatabaseName = databaseName, TableName = tableName, ColumnsList = new List<Columns>()};
                while (reader.Read())
                {
                    item.ColumnsList.Add(new Columns() {Name = reader.GetString(0), Description = reader.GetString(2)});
                }

                list.Add(item);

            }

            reader.Close();
   
        }

        return list;
    }
}