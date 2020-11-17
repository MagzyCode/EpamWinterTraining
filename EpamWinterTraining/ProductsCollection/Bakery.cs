using System;
using System.Collections.Generic;
using System.Text;

namespace EpamWinterTraining.ProductsCollection
{
    public class Bakery<T> where T : Products.IProduct
    {
        public List<T> Products { get; set; }
    }
}
