using System;

namespace EpamWinterTraining.ProductsCollection
{
    public class Bakery<T> where T : Products.IProduct
    {
        private T[] _products;

        public Bakery(T[] products)
        {
            Products = products;
        }
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
