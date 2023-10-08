using System;
using System.Collections.Generic;
using System.IO;
using LoginConsoleApp.Models;

namespace LoginConsoleApp.Classes
{
    public class Operations
    {
        public static string FileName => 
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
                "DataLibrary.dll");

        public static bool FileCheck()
        {
            try
            {
                DeserializeUsers();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        /// <summary>
        /// Create encrypted file with users
        /// </summary>
        public static void SerializeUsers()
        {
            CryptoSerializer<User> cryptoSerializer = new(Secrets.Key);
            using FileStream fileStream = new(FileName, FileMode.OpenOrCreate);
            cryptoSerializer.Serialize(Users, fileStream);
        }

        /// <summary>
        /// Read users from encrypted file
        /// </summary>
        /// <returns></returns>
        public static List<User> DeserializeUsers()
        {
            CryptoSerializer<User> cryptoSerializer = new(Secrets.Key);
            using FileStream fileStream = new(FileName, FileMode.Open);
            return cryptoSerializer.Deserialize(fileStream);

        }

        /// <summary>
        /// Mocked users, change one that works for you or leave as is.
        /// Used in <see cref="SerializeUsers"/>
        /// </summary>
        public static List<User> Users => new()
        {
            new() { Name = "karenpayne", Password = "@miata2019" },
            new() { Name = "bartsimpson", Password = "StupidPassword" },
            new() { Name = "betsy", Password = "@myFlag1776" },
        };

        /// <summary>
        /// Uses <see cref="DeserializeUsers"/> to read back users from a file.
        /// </summary>
        public static void CreateReadUsers()
        {
            SerializeUsers();
            var users = DeserializeUsers();
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name} {user.Password}");
            }
        }
    }
}
