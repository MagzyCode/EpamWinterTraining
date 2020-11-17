using EpamWinterTraining.Products.ProductComponents;
using System.Collections.Generic;

namespace EpamWinterTraining.Products
{
    /// <summary>
    /// Хлебцы
    /// </summary>
    public class Crispbreads : BakeryProduct
    {
        public Crispbreads(List<Ingredient> ingredients, int markup, string title) : base(ingredients, markup, title)
        { }
    }
}
