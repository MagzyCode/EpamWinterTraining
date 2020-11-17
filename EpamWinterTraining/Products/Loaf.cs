using EpamWinterTraining.Products.ProductComponents;
using System.Collections.Generic;

namespace EpamWinterTraining.Products
{
    /// <summary>
    /// Батон
    /// </summary>
    public class Loaf : BakeryProduct
    {
        public Loaf(List<Ingredient> ingredients, int markup, string title) : base(ingredients, markup, title)
        { }
    }
}
