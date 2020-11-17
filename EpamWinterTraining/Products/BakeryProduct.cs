using EpamWinterTraining.Products.ProductComponents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EpamWinterTraining.Products
{
    public abstract class BakeryProduct : IProduct
    {
        private int _markup;
        private string _title;

        public BakeryProduct(List<Ingredient> products, int markup, string title)
        {
            Ingredients = products;
            Markup = markup;
            Title = title;
        }


        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value != string.Empty)
                {
                    _title = value;
                }
                else
                {
                    var productTitle = "Product: " + Guid.NewGuid().ToString();
                    _title = productTitle;
                }
            }
        }
        public int Markup
        {
            get
            {
                return _markup;
            }
            set
            {
                _markup = value > 0 ? value : 0;
            }
        }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public int IngredientAmount
        {
            get
            {
                return Ingredients.Count;
            }
        }

        public int GetProductCalorific()
        {
            var result = Ingredients.Select(i => i.Calorific).Sum();
            return result;
        }
        public int GetProductPrice()
        {
            var result = Ingredients.Select(i => i.Price).Sum();
            return result;
        }
        public int GetProductWeight()
        {
            var totalWeight = Ingredients.Select(i => i.Weight).Sum();
            return totalWeight;
        }

        public override bool Equals(object obj)
        {
            return this == (obj as BakeryProduct);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static bool operator ==(BakeryProduct left, BakeryProduct right)
        {
            var result = (left.GetProductCalorific() == right.GetProductCalorific()) &&
                (left.GetProductPrice() == right.GetProductPrice());
            return result;
        }
        public static bool operator !=(BakeryProduct left, BakeryProduct right)
        {
            var result = !(left == right);
            return result;
        }
    }
}
