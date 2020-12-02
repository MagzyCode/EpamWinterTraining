using EpamWinterTraining.DataAccess;
using EpamWinterTraining.Products;
using EpamWinterTraining.Products.ProductInformation;
using EpamWinterTraining.Products.ProductRadiation;
using EpamWinterTraining.Products.SpecificProducts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSecondTask
{
    public class TestGroceryProduct
    {
        private List<object> _list = JsonConverter.GetJsonInfo();

        private List<Product> _results = new List<Product>()
        {
            /* new GroceryProduct(new ProductInfo("Slonim flour", 125, 1.25, 50), 120), 3 
            new GroceryProduct(new ProductInfo("ABS mayonnaise", 172, 2.14, 200), 450), 4
            new GroceryProduct(new ProductInfo("Honey flower", 162, 3, 39), 324),       5   */

             new GroceryProduct(new ProductInfo("Slonim flour", 125, 1.25, 100), 120),
             new GroceryProduct(new ProductInfo("ABS mayonnaise", 172, 2.14, 400), 450),
             new GroceryProduct(new ProductInfo("Honey flower", 162, 3, 78), 324),

             new GroceryProduct(new ProductInfo("Slonim flour", 125, 1.25, 1), 120),
             new GroceryProduct(new ProductInfo("ABS mayonnaise", 172, 2.14, 400), 450),
             new GroceryProduct(new ProductInfo("Honey flower", 162, 3, 40), 324),

             new BiochemicalProduct(new ProductInfo("Slonim flour", 125, 1.25, 50), 0),
             new BiochemicalProduct(new ProductInfo("ABS mayonnaise", 172, 2.14, 200), 0),
             new BiochemicalProduct(new ProductInfo("Honey flower", 162, 3, 39), 0),

             new GastronomicProduct(new ProductInfo("Slonim flour", 125, 1.25, 50), 120),
             new GastronomicProduct(new ProductInfo("ABS mayonnaise", 172, 2.14, 200), 450),
             new GastronomicProduct(new ProductInfo("Honey flower", 162, 3, 39), 324),

             new HouseholdProduct(new ProductInfo("Slonim flour", 125, 1.25, 50), 0),
             new HouseholdProduct(new ProductInfo("ABS mayonnaise", 172, 2.14, 200), 0),
             new HouseholdProduct(new ProductInfo("Honey flower", 162, 3, 39), 0),

             null
        };

        [TestCase(3, 3, 0, ExpectedResult = true)]
        [TestCase(4, 4, 1, ExpectedResult = true)]
        [TestCase(5, 5, 2, ExpectedResult = true)]
        [TestCase(3, 4, 15, ExpectedResult = false)]
        [TestCase(4, 5, 15, ExpectedResult = false)]
        [TestCase(5, 6, 15, ExpectedResult = false)]
        public bool TestTestAddition(int left, int right, int resultIndex)
        {
            try
            {
                var leftProduct = (GroceryProduct)_list[left];
                var rightProduct = (GroceryProduct)_list[right];
                var result = leftProduct + rightProduct;
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }

        }

        [TestCase(3, 49, 3, ExpectedResult = true)]
        [TestCase(4, -200, 4, ExpectedResult = true)]
        [TestCase(5, -1, 5, ExpectedResult = true)]
        [TestCase(3, 1000, 15, ExpectedResult = false)]
        [TestCase(4, 200, 15, ExpectedResult = false)]
        [TestCase(5, 50, 15, ExpectedResult = false)]
        public bool TestSubstraction(int productIndex, int number, int resultIndex)
        {
            try
            {
                var product = (GroceryProduct)_list[productIndex];
                var result = product - number;
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }
        }

        [TestCase(3, 6, ExpectedResult = true)]
        [TestCase(4, 7, ExpectedResult = true)]
        [TestCase(5, 8, ExpectedResult = true)]
        public bool TestConvertToBiochemicalProduct(int productIndex, int resultIndex)
        {
            try
            {
                var result = (BiochemicalProduct)((GroceryProduct)_list[productIndex]);
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }
        }

        [TestCase(3, 9, ExpectedResult = true)]
        [TestCase(4, 10, ExpectedResult = true)]
        [TestCase(5, 11, ExpectedResult = true)]
        public bool TestConvertToGastronomicProduct(int productIndex, int resultIndex)
        {
            try
            {
                var result = (GastronomicProduct)((GroceryProduct)_list[productIndex]);
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }
        }

        [TestCase(3, 12, ExpectedResult = true)]
        [TestCase(4, 13, ExpectedResult = true)]
        [TestCase(5, 14, ExpectedResult = true)]
        public bool TestConvertToHouseholdProduct(int productIndex, int resultIndex)
        {
            try
            {
                var result = (HouseholdProduct)((GroceryProduct)_list[productIndex]);
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }
        }
    }
}
