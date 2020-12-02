using EpamWinterTraining.DataAccess;
using EpamWinterTraining.Products;
using EpamWinterTraining.Products.ProductInformation;
using EpamWinterTraining.Products.ProductRadiation;
using EpamWinterTraining.Products.SpecificProducts;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace TestingSecondTask
{
    public class TestJsonConverter
    {
        public readonly List<object> list = new List<object>()
        {
            new GastronomicProduct(new ProductInfo("Bread \"Borodinski\"", 145, 1, 100), 150),
            new GastronomicProduct(new ProductInfo("Salmon ROE", 130, 2.25, 145), 900),
            new GastronomicProduct(new ProductInfo("Semi-smoked Cracow sausage", 145, 5.48, 48), 345),
            new GroceryProduct(new ProductInfo("Slonim flour", 125, 1.25, 50), 120),
            new GroceryProduct(new ProductInfo("ABS mayonnaise", 172, 2.14, 200), 450),
            new GroceryProduct(new ProductInfo("Honey flower", 162, 3, 39), 324),
            new BiochemicalProduct(new ProductInfo("Glass cleaner", 128, 7, 20), RadiationGroup.D),
            new BiochemicalProduct(new ProductInfo("Blue paint", 155, 12, 26), RadiationGroup.D),
            new BiochemicalProduct(new ProductInfo("Glue", 162, 3, 39), RadiationGroup.E),
            new HouseholdProduct(new ProductInfo("Purifier", 178, 2.26, 100), RadiationGroup.E),
            new HouseholdProduct(new ProductInfo("Vacuum cleaner", 365, 125.99, 50), RadiationGroup.E),
            new HouseholdProduct(new ProductInfo("Oak table", 266, 345, 15), RadiationGroup.E)
        };

        [Test(ExpectedResult = 12)]
        public int TestSetJsonInfo()
        {
            JsonConverter.SetJsonInfo(list);
            var jsonInfo = File.ReadAllText("products.txt");
            int result = new Regex(@"{.*?}", RegexOptions.Singleline).Matches(jsonInfo).Count;
            return result;
        }

        [Test(ExpectedResult = 12)]
        public int TestGetJsonInfo()
        {
            var list = JsonConverter.GetJsonInfo();
            var i = list[0] as GastronomicProduct;
            // SetJsonInfo(list);
            int result = File.ReadAllLines("products.txt").Length; // list.Count;
            // var jsonInfo = File.ReadAllText("products.txt");
            // int result = new Regex(@"{.*?}", RegexOptions.Singleline).Matches(jsonInfo).Count;
            return result;
        }
        //[SetUp]
        //public void Setup()
        //{
        //}

        // public bool 

    }
}
