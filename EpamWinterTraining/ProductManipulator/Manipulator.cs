using EpamWinterTraining.Products;
using EpamWinterTraining.ProductsCollection;
using System;
using System.Linq;

namespace EpamWinterTraining.ProductManipulator
{
    public class Manipulator
    {
        private Bakery<BakeryProduct> _bakery;

        public Manipulator()
        {
            _bakery = DataReception.FileWork.GetBakery();
        }

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

        public BakeryProduct[] RegularizeProductsByCalorific()
        {
            var products = Bakery.Products.OrderBy(i => i.GetProductCalorific()).ToArray();
            return products;
        }

        public BakeryProduct[] RegularizeProductsByPrice()
        {
            var products = Bakery.Products.OrderBy(i => i.GetProductPrice()).ToArray();
            return products;
        }

        public BakeryProduct[] FindSimilarProducts(BakeryProduct product)
        {
            var products = Bakery.Products.Where(i => i == product).ToArray();
            // var result = products.;
            return products;
        }

        public BakeryProduct[] FindByVolume(string ingredientName, int weight)
        {
            var products = Bakery.Products.
                Where(i => i.Ingredients.Any(e => e.Title == ingredientName && e.Weight > weight)).
                ToArray();
            return products;
            //var result = products.
            //    Where(i => i.Ingredients.Any(e => e.Title == ingredientName && e.Weight > weight)).
            //    ToArray();
            //return result;
        }

        public BakeryProduct[] FindByIngredientAmount(int amount)
        {
            var products = Bakery.Products.Where(i => i.IngredientAmount > amount).ToArray();
            return products;
            // var result = products.Where(i => i.IngredientAmount > amount).ToArray();
            // return result;
        }
    }
}
