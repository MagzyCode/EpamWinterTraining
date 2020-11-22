using EpamWinterTraining.Products;
using EpamWinterTraining.ProductsCollection;
using System;
using System.Linq;

namespace EpamWinterTraining.ProductManipulator
{
    /// <summary>
    /// Class for working with an array of products.
    /// </summary>
    public class Manipulator
    {
        /// <summary>
        /// Product array storage.
        /// </summary>
        private Bakery<BakeryProduct> _bakery;

        public Manipulator()
        {
            _bakery = DataReception.FileWork.GetBakery();
        }

        /// <summary>
        /// The property storage products.
        /// </summary>
        public Bakery<BakeryProduct> Bakery
        {
            get
            {
                return _bakery;
            }
            set
            {
                _bakery = value ?? throw new NullReferenceException("List of products can't be null");
            }
        }

        /// <summary>
        /// Sorts the array of products by calorie content.
        /// </summary>
        /// <returns>Returns a list of foods sorted by calorie content.</returns>
        public BakeryProduct[] RegularizeProductsByCalorific()
        {
            var products = Bakery.Products.OrderBy(i => i.GetProductCalorific()).ToArray();
            return products;
        }

        /// <summary>
        /// Sorts an array of products by price.
        /// </summary>
        /// <returns>Returns a list of products sorted by price.</returns>
        public BakeryProduct[] RegularizeProductsByPrice()
        {
            var products = Bakery.Products.OrderBy(i => i.GetProductPrice()).ToArray();
            return products;
        }

        /// <summary>
        /// Finds products that are equal to you in calories and value.
        /// </summary>
        /// <param name="product">Product for comparison.</param>
        /// <returns>Returns an array of products equal to this product.</returns>
        public BakeryProduct[] FindSimilarProducts(BakeryProduct product)
        {
            var products = Bakery.Products.Where(i => i == product).ToArray();
            return products;
        }

        /// <summary>
        /// Finds products where the volume of some ingredient is greater than the specified value.
        /// </summary>
        /// <param name="ingredientName">Name of the ingredient.</param>
        /// <param name="weight">The volume of the ingredient.</param>
        /// <returns>Returns an array of products whose volume of the specified ingredient is greater than the original value.</returns>
        public BakeryProduct[] FindByVolume(string ingredientName, int weight)
        {
            var products = Bakery.Products.
                Where(i => i.Ingredients.Any(e => e.Title == ingredientName && e.Weight > weight)).
                ToArray();
            return products;
        }

        /// <summary>
        /// Finds products that have more than the specified number of ingredients.
        /// </summary>
        /// <param name="amount">The number of ingredients.</param>
        /// <returns>Returns a list of products that have more than the specified number of ingredients.</returns>
        public BakeryProduct[] FindByIngredientAmount(int amount)
        {
            var products = Bakery.Products.Where(i => i.IngredientAmount > amount).ToArray();
            return products;
        }
    }
}
