using EpamWinterTraining.Products.ProductComponents;
using System.Collections.Generic;

namespace EpamWinterTraining.Products
{
    public class Bagel : BakeryProduct
    {
        public Bagel(List<Ingredient> ingredients, int markup, string title) : base(ingredients, markup, title)
        { }
    }
}
