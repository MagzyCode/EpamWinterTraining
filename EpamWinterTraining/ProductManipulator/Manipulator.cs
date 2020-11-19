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

        public BakeryProduct[] RegularizeProducts()
        {
            var products = Bakery.Products;
            Array.Sort(products);
            return products;
        }

        public BakeryProduct[] FindSimilarProducts(BakeryProduct product)
        {
            var products = Bakery.Products;
            var result = products.Where(i => i == product).ToArray();
            return result;
        }

        public BakeryProduct[] FindByVolume(string ingredientName, int weight)
        {
            var products = Bakery.Products;
            var result = products.
                Where(i => i.Ingredients.Any(e => e.Title == ingredientName && e.Weight > weight)).
                ToArray();
            return result;
        }

        public BakeryProduct[] FindByIngredientAmount(int amount)
        {
            var products = Bakery.Products;
            var result = products.Where(i => i.IngredientAmount > amount).ToArray();
            return result;
        }
    }
}
