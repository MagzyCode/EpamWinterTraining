using EpamWinterTraining.Products.ProductComponents;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace EpamWinterTraining.Products
{
    public class BakeryProduct : IProduct
    {
        /// <summary>
        /// Mark-up on the manufactured product.
        /// </summary>
        private int _markup;
        /// <summary>
        /// Product name.
        /// </summary>
        private string _title;
        /// <summary>
        /// The list of ingredients of the product.
        /// </summary>
        private List<Ingredient> _ingredients = new List<Ingredient>();

        /// <summary>
        /// Initializes the bakery item object.
        /// </summary>
        /// <param name="products">The list of ingredients of the product.</param>
        /// <param name="title">Product name.</param>
        /// <param name="markup">Mark-up on the manufactured product.</param>
        /// <param name="productAmount">Quantity of product in the bakery's warehouse.</param>
        public BakeryProduct(List<Ingredient> products, string title, CategoricalMarkup markup, int productAmount = 1)
        {
            Ingredients = products;
            Markup = (int)markup;
            Title = title;
            ProductCount = productAmount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="products">The list of ingredients of the product.</param>
        /// <param name="markup">Mark-up on the manufactured product.</param>
        /// <param name="title">Product name.</param>
        /// <param name="productAmount">Quantity of product in the bakery's warehouse.</param>
        public BakeryProduct(List<Ingredient> products, int markup, string title, int productAmount = 1)
        {
            Ingredients = products;
            Markup = markup;
            Title = title;
            ProductCount = productAmount;
        }

        /// <summary>
        /// Product name.
        /// </summary>
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
        /// <summary>
        /// Mark-up on the manufactured product.
        /// </summary>
        public int Markup
        {
            get
            {
                return _markup;
            }
            set
            {
                _markup = value > 100 ? value : 100;
            }
        }
        /// <summary>
        /// The list of ingredients of the product.
        /// </summary>
        public List<Ingredient> Ingredients
        {
            get
            {
                return _ingredients;
            }
            set => _ingredients = value ?? throw new NullReferenceException("List of ingredients can't be null");
        }
        /// <summary>
        /// The number of ingredients in the product.
        /// </summary>
        public int IngredientAmount
        {
            get
            {
                return Ingredients.Count;
            }
        }
        /// <summary>
        /// Quantity of product in the bakery's warehouse.
        /// </summary>
        public int ProductCount { get; private set; }

        /// <summary>
        /// Gets the calorie content of one serving of the dish.
        /// </summary>
        /// <returns></returns>
        public int GetProductCalorific()
        {
            var result = Ingredients.Select(i => i.Calorific * i.Weight / 100).Sum();
            return result;
        }
        /// <summary>
        /// Gets the price of one serving of the dish.
        /// </summary>
        /// <returns></returns>
        public double GetProductPrice()
        {
            var result = Ingredients.Select(i => i.Price * i.Weight / 100).Sum() * Markup / 100;
            result = Math.Round(result, 2);
            return result;
        }

        /// <summary>
        /// Gets the weight of one serving of the dish
        /// </summary>
        /// <returns></returns>
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
            return $"{Title}({ProductCount})\n\tMarkup:{Markup}%\n\tIngredients:\n\t\t" +
                $"{string.Join("\n\t\t", Ingredients)}";
        }


        /// <summary>
        /// Compares products for equality by their cost and caloric content.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Returns true if the products are equal in calories and cost.</returns>
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
