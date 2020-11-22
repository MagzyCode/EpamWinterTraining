using System;

namespace EpamWinterTraining.ProductsCollection
{
    /// <summary>
    /// Bakery product storage class.
    /// </summary>
    /// <typeparam name="T">Type that implements the IProduct interface.</typeparam>
    public class Bakery<T> where T : Products.IProduct
    {
        /// <summary>
        /// Array of bakery products.
        /// </summary>
        private T[] _products;

        /// <summary>
        /// Initializes the bakery object.
        /// </summary>
        /// <param name="products">Array of bakery products..</param>
        public Bakery(T[] products)
        {
            Products = products;
        }

        /// <summary>
        /// Property containing an array of bakery products.
        /// </summary>
        public T[] Products
        {
            get
            {
                return (_products.Clone() as T[]);
            }
            private set
            {
                _products = value ?? throw new NullReferenceException("List of products can't be null");
            }
        }
    }
}
