using EpamWinterTraining.Products;
using EpamWinterTraining.Products.ProductComponents;
using EpamWinterTraining.ProductsCollection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace EpamWinterTraining.DataReception
{
    public static class FileWork
    {
        public static Bakery<BakeryProduct> GetBakery(string path = @"products.txt")
        {
            var counter = 0;
            var line = string.Empty;
            int amountOfLines = File.ReadAllLines(path).Length;
            var products = new BakeryProduct[amountOfLines];
            using (var reader = new StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    BakeryProduct product = GetProduct(line);
                    products[counter] = product;
                    counter++;
                }
            }
            var result = new Bakery<BakeryProduct>(products);
            return result;
        }

        private static BakeryProduct GetProduct(string obj)
        {
            var productContentReg = new Regex(@"BakeryProduct{|}}|\s{1,}");
            string productContent = productContentReg.Replace(obj, ""); // .Replace(" ", "")
            string[] properties = productContent.
                Split(';').
                Select(i => i.Split(':')[1]). // .Select(i => i.Replace(" ", "")).
                ToArray();
            var (title, markup, ingredients) = (properties[0], 
                Convert.ToInt32(properties[1]), 
                GetIngredients(properties[2]));
            var product = new BakeryProduct(ingredients, markup, title);
            return product;

            // string 
            // productContentReg.Match(obj).Value
            // List<Ingredient> ingredients = GetIngredients(obj);
            // var ingridients = new Regex
            // var objectContent = productContentReg.Match(obj).Value;
            //var properties = objectContent.
            //    Split(';').
            //    Select(i => i.Split(':')[1]).
            //    Select(i => i.Replace(" ", "")).
            //    ToArray();
            // List<Ingredient> ingredients = GetIngredients(obj);

            // var propertyValues = properties.;

            
        }


        private static List<Ingredient> GetIngredients(string obj)
        {
            var ingredients = new List<Ingredient>();
            // чтобы достать все ингридиенты в строке Ingredient { ... }
            var productContentReg = new Regex(@"^(Ingredient{).+(})$");
            // чтобы удалить все ненужные обёрточные места в строке и пробелы
            var productPropertyReg = new Regex(@"Ingredient{|}|\s{1,}");
            List<string> allIngredients = productContentReg.Matches(obj).Select(i => i.Value).ToList();

            foreach (var ingredient in allIngredients)
            {
                var properties = productPropertyReg.
                    Replace(ingredient, "").
                    Split(';').
                    Select(i => i.Split(':')[1]).
                    ToList();
                var (title, calorific, price, weight) = 
                    (properties[0],
                    Convert.ToInt32(properties[1]),
                    Convert.ToInt32(properties[2]),
                    Convert.ToInt32(properties[3]));
                ingredients.Add(new Ingredient(title, calorific, price, weight));
            }
            return ingredients;

            //var result = allIngredients.
            //    Select(i => productPropertyReg.Replace(i, "")).
            //    Select(i => i.Replace(" ", "")).
            //    Select(i => i.Split(';')).
            //    Select(i => i.Split(":")[1])
            //  return ingredients;
        }

    }
}
