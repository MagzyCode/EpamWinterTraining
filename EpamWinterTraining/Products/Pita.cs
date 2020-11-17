using EpamWinterTraining.Products.ProductComponents;
using System.Collections.Generic;

namespace EpamWinterTraining.Products
{
    /// <summary>
    /// Лаваш
    /// </summary>
    class Pita : BakeryProduct
    {
        public Pita(List<Ingredient> ingredients, int markup, string title) : base(ingredients, markup, title)
        { }
    }
}
