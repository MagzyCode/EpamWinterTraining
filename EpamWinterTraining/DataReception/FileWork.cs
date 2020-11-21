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
            var productHeaderReg = new Regex(@"\t{0}.+");
            var products = new List<BakeryProduct>();
            var productTextContent = new List<string>();
            var line = string.Empty;
            // int productCount = File.ReadAllLines(path).Where(i => productHeaderReg.IsMatch(i)).Count();
            // var products = new BakeryProduct[productCount];

            using (var reader = new StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (((productTextContent.Count == 0) && (productHeaderReg.IsMatch(line))) ||
                        ((productTextContent.Count != 0) && !(productHeaderReg.IsMatch(line))))
                    {
                        productTextContent.Add(line);
                    }
                    else
                    {
                        products.Add(GetProduct(productTextContent));
                        productTextContent.Clear();
                    }

                    //BakeryProduct product = GetProduct(line);
                    //products[counter] = product;
                    //counter++;
                }
            }

            return new Bakery<BakeryProduct>(products.ToArray());
        }

        private static BakeryProduct GetProduct(List<string> obj) 
        {
            // var markupReg = new Regex(@"\t{1}Markup:\s[0-9]+%");
            var markupReg = new Regex(@"\d+");
            var content = new Regex(@"([^\d()]+)|(\d+)");
            var ingredientReg = new Regex(@"\t{2}.+");
            var headerParser = content.Matches(obj[0]).Select(i => i.Value).ToList();
            var (title, productCount) = (headerParser[0], Convert.ToInt32(headerParser[1]));
            int markup = Convert.ToInt32(markupReg.Match(obj[1]).Value);
            var ingredients = GetIngredients(obj.Skip(3).Select(i => i.Replace(" ", "").Replace("\t","")).ToList());
            var product = new BakeryProduct(ingredients, markup, title);
            return product;
        }

        private static List<Ingredient> GetIngredients(List<string> obj) 
        {
            var ingredients = new List<Ingredient>();
            foreach (string ingredient in obj)
            {
                var properties = ingredient.Split(';'); // (new Regex(@"\d+")).Matches(ingredient).Select(i => i.Value).ToArray(); // ingredient.Split(';').Select(i => i.Split(';')[1]).ToArray();
                var (ingredientName, weight, price, calorific) =
                    (
                        properties[0],
                        Convert.ToInt32(properties[1]),
                        Convert.ToInt32(properties[2]),
                        Convert.ToInt32(properties[3])
                    );
                ingredients.Add(new Ingredient(ingredientName, calorific, price, weight));
            }
            return ingredients;
        }

        #region OldVersion



        //public static Bakery<BakeryProduct> GetBakery(string path = @"products.txt")
        //{
        //    var counter = 0;
        //    var line = string.Empty;
        //    int amountOfLines = File.ReadAllLines(path).Length;
        //    var products = new BakeryProduct[amountOfLines];
        //    using (var reader = new StreamReader(path))
        //    {
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            BakeryProduct product = GetProduct(line);
        //            products[counter] = product;
        //            counter++;
        //        }
        //    }
        //    var result = new Bakery<BakeryProduct>(products);
        //    return result;
        //}

        //private static BakeryProduct GetProduct(string obj)
        //{
        //    var productContentReg = new Regex(@"BakeryProduct{|}}|\s{1,}");
        //    string productContent = productContentReg.Replace(obj, ""); // .Replace(" ", "")
        //    string[] properties = productContent.
        //        Split(';').
        //        Select(i => i.Split(':')[1]). // .Select(i => i.Replace(" ", "")).
        //        ToArray();
        //    var (title, markup, ingredients) = (properties[0], 
        //        Convert.ToInt32(properties[1]), 
        //        GetIngredients(properties[2]));
        //    var product = new BakeryProduct(ingredients, markup, title);
        //    return product;            
        //}


        //private static List<Ingredient> GetIngredients(string obj)
        //{
        //    var ingredients = new List<Ingredient>();
        //    // чтобы достать все ингридиенты в строке Ingredient { ... }
        //    var productContentReg = new Regex(@"^(Ingredient{).+(})$");
        //    // чтобы удалить все ненужные обёрточные места в строке и пробелы
        //    var productPropertyReg = new Regex(@"Ingredient{|}|\s{1,}");
        //    List<string> allIngredients = productContentReg.Matches(obj).Select(i => i.Value).ToList();

        //    foreach (var ingredient in allIngredients)
        //    {
        //        var properties = productPropertyReg.
        //            Replace(ingredient, "").
        //            Split(';').
        //            Select(i => i.Split(':')[1]).
        //            ToList();
        //        var (title, calorific, price, weight) = 
        //            (properties[0],
        //            Convert.ToInt32(properties[1]),
        //            Convert.ToInt32(properties[2]),
        //            Convert.ToInt32(properties[3]));
        //        ingredients.Add(new Ingredient(title, calorific, price, weight));
        //    }
        //    return ingredients;
        //}

        #endregion
    }
}
