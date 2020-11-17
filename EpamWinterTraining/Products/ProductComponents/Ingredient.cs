using System;
using System.Collections.Generic;
using System.Text;

namespace EpamWinterTraining.Products.ProductComponents
{
    public class Ingredient
    {
        /// <summary>
        /// Caloric content of the product per hundred grams.
        /// </summary>
        private int _calorific;
        /// <summary>
        /// The price of the product per hundred grams.
        /// </summary>
        private int _price;
        private int _weight;
        private string _title;

        public const int STANDART_GRAMMING = 100;

        public Ingredient(int calorific, int price)
        {
            Calorific = calorific;
            Price = price;
        }

        public Ingredient(int calorific, int price, int weight) : this(calorific, price)
        {
            Weight = weight;
        }

        public int Weight
        {
            get
            {
                return _weight;
            }
            set => _weight = value > 0 ? value : 0;
           
        }

        public int Calorific
        {
            get
            {
                return _calorific;
            }
            private set => _calorific = value > 0 ? value : 0;
        }

        public int Price
        {
            get
            {
                return _price;
            }
            private set => _price = value > 0 ? value : 0;
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

        public int GetProductCalorific()
        {
            var productCalorific = Weight / STANDART_GRAMMING * Calorific;
            return productCalorific;
        }

        public int GetProductPrice()
        {
            var productPrice = Weight / STANDART_GRAMMING * Price;
            return productPrice;
        }


    }
}
