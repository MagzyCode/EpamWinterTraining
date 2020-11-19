using EpamWinterTraining.Products.ProductComponents;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace EpamWinterTraining.Products
{
    public class BakeryProduct : IProduct, IComparable<BakeryProduct>
    {
        private int _markup;
        private string _title;
        private List<Ingredient> _ingredients = new List<Ingredient>();

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
        public List<Ingredient> Ingredients
        {
            get
            {
                return _ingredients;
            }
            set => _ingredients = value ?? throw new NullReferenceException("List of ingredients can't be null");
        }
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
            var result = Ingredients.Select(i => i.Price).Sum() * (Markup + 100) / 100;
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
            return "BakeryProduct{ Title: " + Title + ";" +
                "Markup: " + Markup + ";" +
                "Ingredients: { " + string.Join(' ', Ingredients) + "}}";
            //"Product calorific: " + GetProductCalorific() + ";" +
            //"Product price: " + GetProductPrice() + ";" +
            //"Product weight: " + GetProductWeight() + "; " +

        }

        public int CompareTo(BakeryProduct other)
        {
            return GetProductCalorific().CompareTo(other.GetProductCalorific());
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
