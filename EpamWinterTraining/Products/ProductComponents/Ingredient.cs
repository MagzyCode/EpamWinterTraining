using System;
using System.Collections.Generic;
using System.Text;

namespace EpamWinterTraining.Products.ProductComponents
{
    public class Ingredient
    {
        /// <summary>
        /// Calorific content of the product per hundred grams.
        /// </summary>
        private int _calorific;
        /// <summary>
        /// The price of the product per hundred grams.
        /// </summary>
        private double _price;
        /// <summary>
        /// Weight of the ingredient.
        /// </summary>
        private int _weight;
        /// <summary>
        /// Name of the ingredient.
        /// </summary>
        private string _title;

        /// <summary>
        /// Standard weight unit of calculation.
        /// </summary>
        public const int STANDART_GRAMMING = 100;

        /// <summary>
        /// Initializes the product ingredient object.
        /// </summary>
        /// <param name="title">Name of the ingredient.</param>
        /// <param name="calorific">Caloric content of the product per hundred grams.</param>
        /// <param name="price">The price of the product per hundred grams.</param>
        public Ingredient(string title, int calorific, double price)
        {
            Title = title;
            Calorific = calorific;
            Price = price;
        }

        /// <summary>
        /// Initializes the product ingredient object.
        /// </summary>
        /// <param name="title">Name of the ingredient.</param>
        /// <param name="calorific">Calorific content of the product per hundred grams.</param>
        /// <param name="price">The price of the product per hundred grams.</param>
        /// <param name="weight">Weight of the ingredient.</param>
        public Ingredient(string title, int calorific, double price, int weight) : this(title, calorific, price)
        {
            Weight = weight;
        }


        /// <summary>
        /// Weight of the ingredient.
        /// </summary>
        public int Weight
        {
            get
            {
                return _weight;
            }
            set => _weight = value > 0 ? value : 0;
           
        }

        /// <summary>
        /// Calorific content of the product per hundred grams.
        /// </summary>
        public int Calorific
        {
            get
            {
                return _calorific;
            }
            private set => _calorific = value > 0 ? value : 0;
        }

        /// <summary>
        /// The price of the product per hundred grams.
        /// </summary>
        public double Price
        {
            get
            {
                return _price;
            }
            private set => _price = value > 0 ? value : 0;
        }

        /// <summary>
        /// Name of the ingredient.
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
        /// Calculates the caloric content of an ingredient based on its weight.
        /// </summary>
        /// <returns>Returns the total calorie content of the ingredient.</returns>
        public int GetIngredientCalorific()
        {
            var productCalorific = Weight / STANDART_GRAMMING * Calorific;
            return productCalorific;
        }

        /// <summary>
        /// Calculates the price of an ingredient based on its weight.
        /// </summary>
        /// <returns>Returns the total cost of the ingredient.</returns>
        public double GetIngredientPrice()
        {
            var productPrice = Weight / STANDART_GRAMMING * Price;
            return productPrice;
        }

        public override string ToString()
        {
            return $"{Title}; {Weight} гр.; {Price} руб.; {Calorific} ккал.";
        }


    }
}
