using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace MenuSimpleApp.Classes
{
    public class MockOperations
    {
        /// <summary>
        /// Name of the json file to read from
        /// </summary>
        private static string _fileName => Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "Menu.json");

        /// <summary>
        /// Create a list of months
        /// Information property is not need as we get details from the .json file
        /// </summary>
        /// <returns>List of <see cref="MenuItem"/></returns>
        public static List<MenuItem> MenuItems()
        {

            var list = DateTimeFormatInfo.CurrentInfo.MonthNames[..^1]
                .Select((value, index) => new
                {
                    Name = value, 
                    Id = index + 1
                })
                .ToList().Select(anonymous => new MenuItem()
                {
                    Id = anonymous.Id, 
                    Name = anonymous.Name
                })
                .ToList();

            list.Insert(list.Count, new MenuItem() { Id = -1, Name = "Exit" });

            return list;
        }

        /// <summary>
        /// Read month details from json file
        /// </summary>
        /// <returns>List of <see cref="MenuItem"/></returns>
        public static List<MenuItem> GetMenuItems() 
            => JsonSerializer.Deserialize<List<MenuItem>>(File.ReadAllText(_fileName));

        /// <summary>
        /// Create .json file and note the .Information property is set to
        /// </summary>
        public static void SerializeMonths()
        {
            var json = JsonSerializer.Serialize(MenuItems(), new JsonSerializerOptions()
            {
                WriteIndented = true
            });

            File.WriteAllText(_fileName, json);

        }
    }
}