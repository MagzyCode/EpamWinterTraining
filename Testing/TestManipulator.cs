using EpamWinterTraining.DataReception;
using EpamWinterTraining.ProductManipulator;
using EpamWinterTraining.Products;
using EpamWinterTraining.Products.ProductComponents;
using NUnit.Framework;
using System.Collections.Generic;

namespace Testing
{


    class TestManipulator
    {
        private Manipulator _manipulator;
        
        [SetUp]
        public void Setup()
        {
            _manipulator = new Manipulator() { Bakery = FileWork.GetBakery() };
        }

        [TestCase(ExpectedResult = true)]
        public bool TestRegularizeProductsByCalorific()
        {
            var result = _manipulator.RegularizeProductsByCalorific();
            bool IsSequenceSorted() 
            {
                for (int i = 1; i < result.Length - 1; i++)
                {
                    if (result[i - 1].GetProductCalorific() > result[i].GetProductCalorific())
                    {
                        return false;
                    }
                }
                return true;
            };
            return IsSequenceSorted();
        }

        [TestCase(ExpectedResult = true)]
        public bool TestRegularizeProductsByPrice()
        {
            var result = _manipulator.RegularizeProductsByPrice();
            bool IsSequenceSorted()
            {
                for (int i = 1; i < result.Length - 1; i++)
                {
                    if (result[i - 1].GetProductPrice() > result[i].GetProductPrice())
                    {
                        return false;
                    }
                }
                return true;
            };
            return IsSequenceSorted();
        }

        [TestCase(ExpectedResult = 2)]
        public int TestFindSimilarProducts()
        {
            var ingredients = new List<Ingredient>()
            {
                new Ingredient("Banan", 684, 0.51, 100)
            };
            var product = new BakeryProduct(ingredients, 180, "Dish");
            var result = _manipulator.FindSimilarProducts(product).Length;
            return result;
        }

        [TestCase("Flour", 190, ExpectedResult = 4)]
        [TestCase("Poppy", 46, ExpectedResult = 1)]
        [TestCase("Flour", 150, ExpectedResult = 6)]
        public int TestFindByVolume(string ingredientName, int volume)
        {
            var result = _manipulator.FindByVolume(ingredientName, volume).Length;
            return result;
        }

        [TestCase(3, ExpectedResult = 6)]
        [TestCase(5, ExpectedResult = 1)]
        [TestCase(10, ExpectedResult = 0)]
        public int TestFindByIngredientAmount(int amount)
        {
            var result = _manipulator.FindByIngredientAmount(amount).Length;
            return result;
        }

    }
}
