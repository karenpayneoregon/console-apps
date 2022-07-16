using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MenuConsoleApp.Data;
using MenuConsoleApp.Models;
using Newtonsoft.Json;

namespace MenuConsoleApp.Classes
{
    public class DataOperations
    {
        /// <summary>
        /// Get all categories from database
        /// </summary>
        /// <returns>array of categories</returns>
        public static Categories[] Categories()
        {
            using var context = new NorthwindContext();
            var list = context.Categories.ToList();
            list.Insert(list.Count, new Categories() {CategoryId = -1, CategoryName = "Exit"});
            return list.ToArray();
        }

        public static Categories[] CategoriesArray() => 
            JsonConvert.DeserializeObject<List<Categories>>(
                File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "json", "categories.json")))
                .ToArray();

        public static Products[] ProductsArray() =>
            JsonConvert.DeserializeObject<List<Products>>(
                    File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "json", "products.json")))
                .ToArray();

        public static List<Products> ProductListFromJson(int categoryIdentifier)
        {
            var list = ProductsArray().Where(product => product.CategoryId == categoryIdentifier).ToList();
            list.Insert(list.Count, new Products() { ProductId = -1, ProductName = "Go back" });
            return list;
        }

        /// <summary>
        /// For main menu
        /// </summary>
        /// <param name="categoryIdentifier">category id to get products</param>
        public static List<Products> ProductsList(int categoryIdentifier)
        {
            using var context = new NorthwindContext();
            var list = context.Products.Where(product => product.CategoryId == categoryIdentifier).ToList();
            list.Insert(list.Count, new Products() { ProductId = -1, ProductName = "Go back" });
            return list;
        }

        /// <summary>
        /// List of products by category identifier for product menu
        /// </summary>
        /// <param name="categoryIdentifier">category id to get products</param>
        public static Products[] ProductsMenuList(int categoryIdentifier)
        {
            using var context = new NorthwindContext();
            var list = context.Products.Where(product => product.CategoryId == categoryIdentifier).ToList();
            list.Insert(list.Count, new Products() {ProductId = -1, ProductName = "Go back"});
            return list.ToArray();
        }

        public static void SetProductPrices()
        {
            var products = ProductsArray();

            for (int index = 0; index < products.Length; index++)
            {
                products[index].Price = NumberHelpers.GetRandomNumber(2, 50);
            }

            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText("Products1.json", json);
        }
    }
}
