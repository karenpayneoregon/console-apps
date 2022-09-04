using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateAppSettingsSqlServer.Classes
{
    internal class DataOperations
    {
        public static List<string> DatabaseNames()
        {
            List<string> list = new List<string>();

            var connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=master;integrated security=True;Encrypt=False";

            using var cn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand
            {
                Connection = cn,
                CommandText = "SELECT name FROM sys.databases WHERE name NOT IN ('master', 'tempdb','msdb', 'model') ORDER BY name"
            };

            cn.Open();
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(reader.GetString(0));
            }

            return list;
        }
    }
}
