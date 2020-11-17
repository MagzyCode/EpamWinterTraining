using EpamWinterTraining.Products.ProductComponents;
using System.Collections.Generic;

namespace EpamWinterTraining.Products
{
    /// <summary>
    /// Булочка
    /// </summary>
    public class Bun : BakeryProduct
    {
        public Bun(List<Ingredient> ingredients, int markup, string title) : base(ingredients, markup, title)
        { }
    }
}
