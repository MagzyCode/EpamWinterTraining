using EpamWinterTraining.DataReception;
using EpamWinterTraining.Products;
using EpamWinterTraining.ProductsCollection;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Linq;

namespace Testing
{
    public class TestBakeryProduct
    {
        private Bakery<BakeryProduct> Bakery { get; set; } = FileWork.GetBakery();

        [TestCase(0, ExpectedResult = 684)]
        [TestCase(1, ExpectedResult = 684)]
        [TestCase(2, ExpectedResult = 730)]
        [TestCase(3, ExpectedResult = 744)]
        [TestCase(4, ExpectedResult = 700)]
        [TestCase(5, ExpectedResult = 1290)]
        [TestCase(6, ExpectedResult = 617)]
        [TestCase(7, ExpectedResult = 842)]
        public int TestGetProductCalorific(int elementIndex)
        {
            return Bakery.Products[elementIndex].GetProductCalorific();
        }

        [TestCase(0, ExpectedResult = 0.92)]
        [TestCase(1, ExpectedResult = 0.92)]
        [TestCase(2, ExpectedResult = 2.33)]
        [TestCase(3, ExpectedResult = 2.22)]
        [TestCase(4, ExpectedResult = 0.88)]
        [TestCase(5, ExpectedResult = 1.16)]
        [TestCase(6, ExpectedResult = 2.16)]
        [TestCase(7, ExpectedResult = 2.66)]
        public double TestGetProductPrice(int elementIndex)
        {
            return Bakery.Products[elementIndex].GetProductPrice();
        }

        [TestCase(0, ExpectedResult = 310)]
        [TestCase(1, ExpectedResult = 310)]
        [TestCase(2, ExpectedResult = 300)]
        [TestCase(3, ExpectedResult = 320)]
        [TestCase(4, ExpectedResult = 315)]
        [TestCase(5, ExpectedResult = 851)]
        [TestCase(6, ExpectedResult = 330)]
        [TestCase(7, ExpectedResult = 270)]
        public int TestGetProductWeight(int elementIndex)
        {
            return Bakery.Products[elementIndex].GetProductWeight();
        }

        [TestCase(0, 1, ExpectedResult = true)]
        public bool TestOperatorEqual(int leftOperandIndex, int rightOperandIndex)
        {
            return Bakery.Products[leftOperandIndex] == Bakery.Products[rightOperandIndex];
        }
    }
}
