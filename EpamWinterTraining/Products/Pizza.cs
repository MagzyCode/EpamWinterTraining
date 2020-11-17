using EpamWinterTraining.Products.ProductComponents;
using System.Collections.Generic;

namespace EpamWinterTraining.Products
{
    class Pizza : BakeryProduct
    {
        public Pizza(List<Ingredient> ingredients, int markup, string title) : base(ingredients, markup, title)
        { }
    }
}
