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
    public class TestBiochemicalProduct
    {
        private List<object> _list = JsonConverter.GetJsonInfo();
        
        private List<Product> _results = new List<Product>()
        {
             new BiochemicalProduct(new ProductInfo("Glass cleaner", 128, 7, 40), RadiationGroup.D),
             new BiochemicalProduct(new ProductInfo("Blue paint", 155, 12, 52), RadiationGroup.D),
             new BiochemicalProduct(new ProductInfo("Glue", 162, 3, 78), RadiationGroup.E),

             new BiochemicalProduct(new ProductInfo("Glass cleaner", 128, 7, 1), RadiationGroup.D),
             new BiochemicalProduct(new ProductInfo("Blue paint", 155, 12, 40), RadiationGroup.D),
             new BiochemicalProduct(new ProductInfo("Glue", 162, 3, 70), RadiationGroup.E),

             new GastronomicProduct(new ProductInfo("Glass cleaner", 128, 7, 20), 0),
             new GastronomicProduct(new ProductInfo("Blue paint", 155, 12, 26), 0),
             new GastronomicProduct(new ProductInfo("Glue", 162, 3, 39), 0),

             new GroceryProduct(new ProductInfo("Glass cleaner", 128, 7, 20), 0),
             new GroceryProduct(new ProductInfo("Blue paint", 155, 12, 26), 0),
             new GroceryProduct(new ProductInfo("Glue", 162, 3, 39), 0),

             new HouseholdProduct(new ProductInfo("Glass cleaner", 128, 7, 20), RadiationGroup.D),
             new HouseholdProduct(new ProductInfo("Blue paint", 155, 12, 26), RadiationGroup.D),
             new HouseholdProduct(new ProductInfo("Glue", 162, 3, 39), RadiationGroup.E),

             null
        };

        [TestCase(6, 6, 0, ExpectedResult = true)]
        [TestCase(7, 7, 1, ExpectedResult = true)]
        [TestCase(8, 8, 2, ExpectedResult = true)]
        [TestCase(6, 7, 15, ExpectedResult = false)]
        [TestCase(7, 8, 15, ExpectedResult = false)]
        [TestCase(6, 8, 15, ExpectedResult = false)]
        public bool TestTestAddition(int left, int right, int resultIndex)
        {
            try
            {
                var leftProduct = (BiochemicalProduct)_list[left];
                var rightProduct = (BiochemicalProduct)_list[right];
                var result = leftProduct + rightProduct;
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }
            
        }

        [TestCase(6, 19, 3, ExpectedResult = true)]
        [TestCase(7, -14, 4, ExpectedResult = true)]
        [TestCase(8, -31, 5, ExpectedResult = true)]
        [TestCase(6, 150, 15, ExpectedResult = false)]
        [TestCase(7, 26, 15, ExpectedResult = false)]
        [TestCase(6, 79, 15, ExpectedResult = false)]
        public bool TestSubstraction(int productIndex, int number, int resultIndex)
        {
            try
            {
                var product = (BiochemicalProduct)_list[productIndex];
                var result = product - number;
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }
        }

        [TestCase(6, 6, ExpectedResult = true)]
        [TestCase(7, 7, ExpectedResult = true)]
        [TestCase(8, 8, ExpectedResult = true)]
        public bool TestConvertToGastronomicProduct(int productIndex, int resultIndex)
        {
            try
            {
                var result = (GastronomicProduct)((BiochemicalProduct)_list[productIndex]);
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }
        }

        [TestCase(6, 9, ExpectedResult = true)]
        [TestCase(7, 10, ExpectedResult = true)]
        [TestCase(8, 11, ExpectedResult = true)]
        public bool TestConvertToGroceryProduct(int productIndex, int resultIndex)
        {
            try
            {
                var result = (GroceryProduct)((BiochemicalProduct)_list[productIndex]);
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }
        }

        [TestCase(6, 12, ExpectedResult = true)]
        [TestCase(7, 13, ExpectedResult = true)]
        [TestCase(8, 14, ExpectedResult = true)]
        public bool TestConvertToHouseholdProduct(int productIndex, int resultIndex)
        {
            try
            {
                var result = (HouseholdProduct)((BiochemicalProduct)_list[productIndex]);
                return result.Equals(_results[resultIndex]);
            }
            catch
            {
                return false;
            }
        }

    }
}
