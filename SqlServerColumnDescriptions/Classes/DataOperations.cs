using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLibrary.LanguageExtensions;
using SqlServerColumnDescriptions.Models;

namespace SqlServerColumnDescriptions.Classes
{
    internal class DataOperations
    {
        private static readonly string MasterConnectionString =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=master;integrated security=True;Encrypt=False";


        public static List<DatabaseName> DatabaseNames()
        {
            List<DatabaseName> list = new();
            int identifier = 1;
            using var cn = new SqlConnection(MasterConnectionString);
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

        public static List<DatabaseTable> GetDetails(string databaseName)
        {
            List<DatabaseTable> list = new ();

            using var cn = new SqlConnection($"Data Source=.\\SQLEXPRESS;Initial Catalog={databaseName};integrated security=True;Encrypt=False");
            using var cmd = new SqlCommand { Connection = cn, CommandText = SqlStatements.GetTableNames(databaseName) };
            cn.Open();
            using var reader = cmd.ExecuteReader();


            List<string> names = new List<string>();
            while (reader.Read())
            {
                names.Add(reader.GetString(0).Replace("dbo.", ""));
            }


            return GetDescriptions(databaseName, names);
        }

        public static List<DatabaseTable> GetDescriptions(string databaseName,List<string> tableNames)
        {
            List<DatabaseTable> list = new();
            using var cn = new SqlConnection($"Data Source=.\\SQLEXPRESS;Initial Catalog={databaseName};integrated security=True;Encrypt=False");
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
}
