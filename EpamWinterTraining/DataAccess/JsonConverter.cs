using EpamWinterTraining.Products.SpecificProducts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text.RegularExpressions;

namespace EpamWinterTraining.DataAccess
{
    /// <summary>
    /// Saves and uploads product data in a text file in Json format.
    /// </summary>
    public static class JsonConverter
    {
        /// <summary>
        /// Retrieves a list of products from a text file.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns>Returns a list of products.</returns>
        public static List<object> GetJsonInfo(string path = "products.txt")
        {
            var lines = File.ReadAllLines(path);
            var list = new List<object>();
            foreach (string line in lines)
            {
                string obj = Regex.Replace(line, "{|}|\\|\"", "");
                var prop = obj.Split(',').Where(i => i.Contains("Type")).First();
                var stringType = Regex.Match(prop.Split(':')[1], @"\w+").Value;
                var type = GetProductType(stringType);
                var item = JsonSerializer.Deserialize(line, type);
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// Saves the list of products to a text file.
        /// </summary>
        /// <param name="products">List of products.</param>
        /// <param name="path">File path.</param>
        public static void SetJsonInfo(List<object> products, string path = "products.txt")
        {
            using var writer = new StreamWriter(path);
            foreach (var product in products)
            {
                var jsonInfo = JsonSerializer.Serialize(product);
                writer.WriteLine(jsonInfo);
            }
        }

        /// <summary>
        /// Converts a string to a specific product type.
        /// </summary>
        /// <param name="type">String name of the specific product type.</param>
        /// <returns>Product type.</returns>
        private static Type GetProductType(string type) => type switch
        {
            "GroceryProduct" => typeof(GroceryProduct),
            "BiochemicalProduct" => typeof(BiochemicalProduct),
            "GastronomicProduct" => typeof(GastronomicProduct),
            "HouseholdProduct" => typeof(HouseholdProduct),
            _ => throw new Exception()
        };
    }
}
