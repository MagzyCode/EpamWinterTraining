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
    public class TestHouseholdProduct
    {
        private List<object> _list = JsonConverter.GetJsonInfo();

        private List<Product> _results = new List<Product>()
        {

            /*new HouseholdProduct(new ProductInfo("Purifier", 178, 2.26, 100), RadiationGroup.E), 9
            new HouseholdProduct(new ProductInfo("Vacuum cleaner", 365, 125.99, 50), RadiationGroup.E), 10
            new HouseholdProduct(new ProductInfo("Oak table", 266, 345, 15), RadiationGroup.E)   11*/
             new HouseholdProduct(new ProductInfo("Purifier", 178, 2.26, 200), RadiationGroup.E),
             new HouseholdProduct(new ProductInfo("Vacuum cleaner", 365, 125.99, 100), RadiationGroup.E),
             new HouseholdProduct(new ProductInfo("Oak table", 266, 345, 30), RadiationGroup.E),

             new HouseholdProduct(new ProductInfo("Purifier", 178, 2.26, 1), RadiationGroup.E),
             new HouseholdProduct(new ProductInfo("Vacuum cleaner", 365, 125.99, 40), RadiationGroup.E),
             new HouseholdProduct(new ProductInfo("Oak table", 266, 345, 40), RadiationGroup.E),

             new GastronomicProduct(new ProductInfo("Purifier", 178, 2.26, 100), 0),
             new GastronomicProduct(new ProductInfo("Vacuum cleaner", 365, 125.99, 50), 0),
             new GastronomicProduct(new ProductInfo("Oak table", 266, 345, 15), 0),

             new GroceryProduct(new ProductInfo("Purifier", 178, 2.26, 100), 0),
             new GroceryProduct(new ProductInfo("Vacuum cleaner", 365, 125.99, 50), 0),
             new GroceryProduct(new ProductInfo("Oak table", 266, 345, 15), 0),

             new BiochemicalProduct(new ProductInfo("Purifier", 178, 2.26, 100), RadiationGroup.E),
             new BiochemicalProduct(new ProductInfo("Vacuum cleaner", 365, 125.99, 50), RadiationGroup.E),
             new BiochemicalProduct(new ProductInfo("Oak table", 266, 345, 15), RadiationGroup.E),

             null
        };

        [TestCase(9, 9, 0, ExpectedResult = true)]
        [TestCase(10, 10, 1, ExpectedResult = true)]
        [TestCase(11, 11, 2, ExpectedResult = true)]
        [TestCase(9, 10, 15, ExpectedResult = false)]
        [TestCase(10, 11, 15, ExpectedResult = false)]
        [TestCase(9, 11, 15, ExpectedResult = false)]
        public bool TestTestAddition(int left, int right, int resultIndex)
        {
            try
            {
                var leftProduct = (HouseholdProduct)_list[left];
                var rightProduct = (HouseholdProduct)_list[right];
                var result = leftProduct + rightProduct;
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }

        }

        [TestCase(9, 99, 3, ExpectedResult = true)]
        [TestCase(10, 10, 4, ExpectedResult = true)]
        [TestCase(11, -25, 5, ExpectedResult = true)]
        [TestCase(9, 150, 15, ExpectedResult = false)]
        [TestCase(10, 26, 15, ExpectedResult = false)]
        [TestCase(11, 79, 15, ExpectedResult = false)]
        public bool TestSubstraction(int productIndex, int number, int resultIndex)
        {
            try
            {
                var product = (HouseholdProduct)_list[productIndex];
                var result = product - number;
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }
        }

        [TestCase(9, 6, ExpectedResult = true)]
        [TestCase(10, 7, ExpectedResult = true)]
        [TestCase(11, 8, ExpectedResult = true)]
        public bool TestConvertToGastronomicProduct(int productIndex, int resultIndex)
        {
            try
            {
                var result = (GastronomicProduct)((HouseholdProduct)_list[productIndex]);
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }
        }

        [TestCase(9, 9, ExpectedResult = true)]
        [TestCase(10, 10, ExpectedResult = true)]
        [TestCase(11, 11, ExpectedResult = true)]
        public bool TestConvertToGroceryProduct(int productIndex, int resultIndex)
        {
            try
            {
                var result = (GroceryProduct)((HouseholdProduct)_list[productIndex]);
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }
        }

        [TestCase(9, 12, ExpectedResult = true)]
        [TestCase(10, 13, ExpectedResult = true)]
        [TestCase(11, 14, ExpectedResult = true)]
        public bool TestConvertToBiochemicalProduct(int productIndex, int resultIndex)
        {
            try
            {
                var result = (BiochemicalProduct)((HouseholdProduct)_list[productIndex]);
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }
        }
    }
}
