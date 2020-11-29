using EpamWinterTraining.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EpamWinterTraining.DataAccess
{
    public static class JsonConverter
    {
        
        public static List<Product> GetJsonInfo(string path = "products.txt")
        {
            using var reader = new StreamReader(path);
            List<Product> products = (List<Product>)JsonSerializer.Deserialize(reader.ReadToEnd(), typeof(List<Product>));
            return products;
        }

        public static void SetJsonInfo(List<Product> products, string path = "products.txt")
        {
            using var writer = new StreamWriter(path);
            JsonSerializer.Serialize(products, typeof(List<Product>));
        }
    }
}
