using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GenerateAppSettingsSqlServer.Models;

namespace GenerateAppSettingsSqlServer.Classes
{
    internal class FileOperations
    {
        public static void WriteFile(Options options, string databaseName)
        {
            var baseConnection1 = 
                $"Data Source=.\\SQLEXPRESS;Initial Catalog={databaseName};" + 
                $"integrated security=True;Encrypt=True";

            var baseConnection2 =
                $"Data Source=.\\SQLEXPRESS;Initial Catalog={databaseName};" +
                $"integrated security=True;";


            var useEncryption = options.UseEncryption.ToLower() == "yes";

            Configuration configuration = new Configuration()
            {
                ActiveEnvironment = "Development", 
                Development = useEncryption ? baseConnection1 : baseConnection2, 
                Production = useEncryption ? baseConnection1 : baseConnection2, 
                Stage = useEncryption ? baseConnection1 : baseConnection2
            };

            string jsonString = JsonSerializer.Serialize(configuration, new JsonSerializerOptions()
            {
                WriteIndented = true
            });

            File.WriteAllText(Path.Combine(options.Folder,"appsettings.json"), jsonString);
        }
    }
}
