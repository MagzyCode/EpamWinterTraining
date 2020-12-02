using EpamWinterTraining.DataAccess;
using EpamWinterTraining.Products;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingSecondTask
{
    public class TestProduct
    {
        private List<object> list;

        [SetUp]
        public void Setup()
        {
            list = JsonConverter.GetJsonInfo();
        }

        [TestCase(0, ExpectedResult = 1.45)]
        [TestCase(1, ExpectedResult = 2.92)]
        [TestCase(2, ExpectedResult = 7.95)]
        [TestCase(3, ExpectedResult = 1.56)]
        [TestCase(4, ExpectedResult = 3.68)]
        [TestCase(5, ExpectedResult = 4.86)]
        [TestCase(6, ExpectedResult = 8.96)]
        [TestCase(7, ExpectedResult = 18.6)]
        [TestCase(8, ExpectedResult = 4.86)]
        [TestCase(9, ExpectedResult = 4.02)]
        [TestCase(10, ExpectedResult = 459.86)]
        [TestCase(11, ExpectedResult = 917.70)]
        public double TestGetSingleProductPrice(int index)
        {
            var result = (list[index] as Product).GetSingleProductPrice();
            return result;
        }
        
        [TestCase(ExpectedResult = 39966.38)]
        public double TestGetTotalProductPrice()
        {
            var result = list.Select(i => (i as Product).GetTotalProductPrice()).Sum();
            return Math.Round(result, 2);
        }

        [TestCase(0, ExpectedResult = 145)]
        [TestCase(1, ExpectedResult = 292)]
        [TestCase(2, ExpectedResult = 794)]
        [TestCase(3, ExpectedResult = 156)]
        [TestCase(4, ExpectedResult = 368)]
        [TestCase(5, ExpectedResult = 486)]
        [TestCase(6, ExpectedResult = 896)]
        [TestCase(7, ExpectedResult = 1860)]
        [TestCase(8, ExpectedResult = 486)]
        [TestCase(9, ExpectedResult = 402)]
        [TestCase(10, ExpectedResult = 45986)]
        [TestCase(11, ExpectedResult = 91770)]
        public int TestConvertToInt(int index)
        {
            var result = (int)(list[index] as Product);
            return result;
        }

        [TestCase(0, ExpectedResult = 1.45)]
        [TestCase(1, ExpectedResult = 2.92)]
        [TestCase(2, ExpectedResult = 7.95)]
        [TestCase(3, ExpectedResult = 1.56)]
        [TestCase(4, ExpectedResult = 3.68)]
        [TestCase(5, ExpectedResult = 4.86)]
        [TestCase(6, ExpectedResult = 8.96)]
        [TestCase(7, ExpectedResult = 18.6)]
        [TestCase(8, ExpectedResult = 4.86)]
        [TestCase(9, ExpectedResult = 4.02)]
        [TestCase(10, ExpectedResult = 459.86)]
        [TestCase(11, ExpectedResult = 917.70)]
        public double TestConvertToDouble(int index)
        {
            var result = (double)(list[index] as Product);
            return result;
        }


    }
}
