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
    public class TestGastronomicProduct
    {
        private List<object> _list = JsonConverter.GetJsonInfo();

        private List<Product> _results = new List<Product>()
        {
            /*new GastronomicProduct(new ProductInfo("Bread \"Borodinski\"", 145, 1, 100), 150), 0 
            new GastronomicProduct(new ProductInfo("Salmon ROE", 130, 2.25, 145), 900), 1 
            new GastronomicProduct(new ProductInfo("Semi-smoked Cracow sausage", 145, 5.48, 48), 345), 2*/

             new GastronomicProduct(new ProductInfo("Bread \"Borodinski\"", 145, 1, 200), 150),
             new GastronomicProduct(new ProductInfo("Salmon ROE", 130, 2.25, 290), 900),
             new GastronomicProduct(new ProductInfo("Semi-smoked Cracow sausage", 145, 5.48, 96), 345),

             new GastronomicProduct(new ProductInfo("Bread \"Borodinski\"", 145, 1, 1), 150),
             new GastronomicProduct(new ProductInfo("Salmon ROE", 130, 2.25, 45), 900),
             new GastronomicProduct(new ProductInfo("Semi-smoked Cracow sausage", 145, 5.48, 50), 345),

             new BiochemicalProduct(new ProductInfo("Bread \"Borodinski\"", 145, 1, 100), 0),
             new BiochemicalProduct(new ProductInfo("Salmon ROE", 130, 2.25, 145), 0),
             new BiochemicalProduct(new ProductInfo("Semi-smoked Cracow sausage", 145, 5.48, 48), 0),

             new GroceryProduct(new ProductInfo("Bread \"Borodinski\"", 145, 1, 100), 150),
             new GroceryProduct(new ProductInfo("Salmon ROE", 130, 2.25, 145), 900),
             new GroceryProduct(new ProductInfo("Semi-smoked Cracow sausage", 145, 5.48, 48), 345),

             new HouseholdProduct(new ProductInfo("Bread \"Borodinski\"", 145, 1, 100), 0),
             new HouseholdProduct(new ProductInfo("Salmon ROE", 130, 2.25, 145), 0),
             new HouseholdProduct(new ProductInfo("Semi-smoked Cracow sausage", 145, 5.48, 48), 0),

             null
        };

        [TestCase(0, 0, 0, ExpectedResult = true)]
        [TestCase(1, 1, 1, ExpectedResult = true)]
        [TestCase(2, 2, 2, ExpectedResult = true)]
        [TestCase(0, 1, 15, ExpectedResult = false)]
        [TestCase(1, 2, 15, ExpectedResult = false)]
        [TestCase(0, 2, 15, ExpectedResult = false)]
        public bool TestTestAddition(int left, int right, int resultIndex)
        {
            try
            {
                var leftProduct = (GastronomicProduct)_list[left];
                var rightProduct = (GastronomicProduct)_list[right];
                var result = leftProduct + rightProduct;
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }

        }

        [TestCase(0, 99, 3, ExpectedResult = true)]
        [TestCase(1, 100, 4, ExpectedResult = true)]
        [TestCase(2, -2, 5, ExpectedResult = true)]
        [TestCase(0, 1000, 15, ExpectedResult = false)]
        [TestCase(1, 145, 15, ExpectedResult = false)]
        [TestCase(2, 48, 15, ExpectedResult = false)]
        public bool TestSubstraction(int productIndex, int number, int resultIndex)
        {
            try
            {
                var product = (GastronomicProduct)_list[productIndex];
                var result = product - number;
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }
        }

        [TestCase(0, 6, ExpectedResult = true)]
        [TestCase(1, 7, ExpectedResult = true)]
        [TestCase(2, 8, ExpectedResult = true)]
        public bool TestConvertToBiochemicalProduct(int productIndex, int resultIndex)
        {
            try
            {
                var result = (BiochemicalProduct)((GastronomicProduct)_list[productIndex]);
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }
        }

        [TestCase(0, 9, ExpectedResult = true)]
        [TestCase(1, 10, ExpectedResult = true)]
        [TestCase(2, 11, ExpectedResult = true)]
        public bool TestConvertToGroceryProduct(int productIndex, int resultIndex)
        {
            try
            {
                var result = (GroceryProduct)((GastronomicProduct)_list[productIndex]);
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }
        }

        [TestCase(0, 12, ExpectedResult = true)]
        [TestCase(1, 13, ExpectedResult = true)]
        [TestCase(2, 14, ExpectedResult = true)]
        public bool TestConvertToHouseholdProduct(int productIndex, int resultIndex)
        {
            try
            {
                var result = (HouseholdProduct)((GastronomicProduct)_list[productIndex]);
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }
        }
    }
}
