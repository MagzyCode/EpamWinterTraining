using EpamWinterTraining.DataReception;
using EpamWinterTraining.Products;
using EpamWinterTraining.ProductsCollection;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Linq;

namespace Testing
{
    
    public class TestFileWork
    {
        private Bakery<BakeryProduct> Bakery { get; set; }

        [SetUp]
        public void Setup()
        {
            Bakery = FileWork.GetBakery();
        }

        [TestCase(8, ExpectedResult =  true)]
        public bool TestGetBakery(int expected)
        {
            return Bakery.Products.Length == expected;
        }
    }
}