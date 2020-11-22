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
    /// <summary>
    /// Class for working with a text file with bakery products.
    /// </summary>
    public static class FileWork
    {

        /// <summary>
        /// Getting an array of baked goods from a text file.
        /// </summary>
        /// <param name="path">File path.</param>
        /// <returns>Returns the storage class with bakery products.</returns>
        public static Bakery<BakeryProduct> GetBakery(string path = @"products.txt")
        {
            var lines = File.ReadAllLines(path);
            var productHeaderReg = new Regex(@"\t{0}.+");
            var productPropertyReg = new Regex(@"\t{1,2}.+");
            var products = new List<BakeryProduct>();
            var productTextContent = new List<string>();

            foreach (string line in lines)
            {
                if (((productTextContent.Count == 0) && (productHeaderReg.IsMatch(line))) ||
                    ((productTextContent.Count != 0) && (productPropertyReg.IsMatch(line))))
                {
                    productTextContent.Add(line);
                }
                else
                {
                    products.Add(GetProduct(productTextContent));
                    productTextContent = new List<string>() { line };
                }
            }
            products.Add(GetProduct(productTextContent));
            return new Bakery<BakeryProduct>(products.ToArray());
        }

        /// <summary>
        /// Retrieves a bakery product from a group of lines in the file.
        /// </summary>
        /// <param name="obj">A list of lines containing information about the product.</param>
        /// <returns>Returns the bakery product.</returns>
        private static BakeryProduct GetProduct(List<string> obj) 
        {
            var headerParser = Regex.Matches(obj[0], @"([^\d()]+)|(\d+)").Select(i => i.Value).ToList();
            var (title, productCount) = (headerParser[0], Convert.ToInt32(headerParser[1]));
            int markup = Convert.ToInt32(Regex.Match(obj[1], @"\d+").Value);
            var ingredients = GetIngredients(obj.Skip(3).Select(i => Regex.Replace(i, @"[\t\s]+", "")).ToList());
            var product = new BakeryProduct(ingredients, markup, title, productCount);
            return product;
        }

        /// <summary>
        /// Parses the list of strings to the list of ingredients.
        /// </summary>
        /// <param name="obj">A list of lines containing information about the ingredient</param>
        /// <returns>Returns a list of ingredients.</returns>
        private static List<Ingredient> GetIngredients(List<string> obj) 
        {
            var numberReg = new Regex(@"(\d+[.,]\d{2})|(\d+)");
            var ingredients = new List<Ingredient>();
            foreach (string ingredient in obj)
            {
                var properties = ingredient.Split(';');
                var ingredientName = properties[0];
                var weight = Convert.ToInt32(numberReg.Match(properties[1]).Value);
                var price = Convert.ToDouble(numberReg.Match(properties[2]).Value);
                var calorific = Convert.ToInt32(numberReg.Match(properties[3]).Value);
                ingredients.Add(new Ingredient(ingredientName, calorific, price, weight));
            }
            return ingredients;
        } 
    }
}
