using EpamWinterTraining.Products.ProductComponents;
using System.Collections.Generic;

namespace EpamWinterTraining.Products
{
    /// <summary>
    /// Хлеб
    /// </summary>
    public class Bread : BakeryProduct
    {
        public Bread(List<Ingredient> ingredients, int markup, string title) : base(ingredients, markup, title)
        { }
    }
}
