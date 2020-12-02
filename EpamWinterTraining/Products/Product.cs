using EpamWinterTraining.ProductExceptions;
using EpamWinterTraining.Products.ProductInformation;
using System;

namespace EpamWinterTraining.Products
{
    public class Product : IProduct
    {
        /// <summary>
        /// Basic information about the product.
        /// </summary>
        private protected ProductInfo _productInfo;

        private protected Product()
        { }

        /// <summary>
        /// Initializes an object of the type Product.
        /// </summary>
        /// <param name="productInfo">Basic information about the product.</param>
        public Product(ProductInfo productInfo)
        {
            Title = productInfo.Title;
            Markup = productInfo.Markup;
            PurchasePrice = productInfo.PurchasePrice;
            ProductUnitNumber = productInfo.ProductUnitNumber;
            ProductType = GetType().Name;
        }

        /// <summary>
        /// Type of goods.
        /// </summary>
        public string ProductType { get; set; }

        /// <summary>
        /// Name of produce.
        /// </summary>
        public string Title
        {
            get
            {
                return _productInfo.Title;
            }
            set
            {
                _productInfo.Title = value;
            }
        }

        /// <summary>
        /// The number of units of the product.
        /// </summary>
        public int ProductUnitNumber
        {
            get
            {
                return _productInfo.ProductUnitNumber;
            }
            set
            {
                _productInfo.ProductUnitNumber = value; 
            }
        }

        /// <summary>
        /// The markup on the product.
        /// </summary>
        public int Markup
        {
            get
            {
                return _productInfo.Markup;
            }
            set
            {
                _productInfo.Markup = value;
            }
        }

        /// <summary>
        /// Purchase price for the product.
        /// </summary>
        public double PurchasePrice
        {
            get
            {
                return _productInfo.PurchasePrice;
            }
            set
            {
                _productInfo.PurchasePrice = value;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Product info &&
                   info._productInfo == _productInfo;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, ProductUnitNumber, Markup, PurchasePrice);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// Getting the cost per unit of production, taking into account the markup.
        /// </summary>
        /// <returns></returns>
        public double GetSingleProductPrice()
        {
            return Math.Round(((PurchasePrice * Markup) / 100), 2);
        }


        /// <summary>
        /// Getting the total cost of products, including margins and the number of units.
        /// </summary>
        /// <returns></returns>
        public double GetTotalProductPrice()
        {
            return Math.Round((GetSingleProductPrice() * ProductUnitNumber), 2);
        }

        /// <summary>
        /// The conversion prices of the goods to the penny.
        /// </summary>
        /// <param name="product">A convertible product.</param>
        public static explicit operator int(Product product)
        {
            var result = (int)(product.PurchasePrice * product.Markup);
            return result;
        }

        /// <summary>
        /// Converting a product to a real type.
        /// </summary>
        /// <param name="product">A convertible product.</param>
        public static explicit operator double(Product product)
        {
            var result = Math.Round((product.PurchasePrice * product.Markup / 100), 2);
            return result;
        }

        /// <summary>
        /// Initialize the basic information about the product with the sum of two products.
        /// </summary>
        /// <param name="left">Left operator.</param>
        /// <param name="right">Right operator.</param>
        /// <returns></returns>
        private protected static ProductInfo GetAddition(Product left, Product right)
        {
            if (left.Title != right.Title)
            {
               throw new ImpossibleOperationException("It is not possible to add products due to " +
                   "a mismatch in the name.");
            }
            var count = left.ProductUnitNumber + right.ProductUnitNumber;
            var markup = (left.Markup * left.ProductUnitNumber +
                right.Markup * right.ProductUnitNumber) / count;
            var price = (left.PurchasePrice * left.ProductUnitNumber +
                right.PurchasePrice * right.ProductUnitNumber) / count;
            var productInfo = new ProductInfo(left.Title, markup, price, count);

            return productInfo;
        }

        /// <summary>
        /// Gets a new product by subtracting the number of product units from the specified product.
        /// </summary>
        /// <typeparam name="T">Product type.</typeparam>
        /// <param name="product">Converted produc.</param>
        /// <param name="number">The subtracted number of product units.</param>
        /// <returns></returns>
        private protected static T GetSubtraction<T>(T product, int number) where T : Product
        {
            if (product.ProductUnitNumber < number)
            {
                throw new ImpossibleOperationException("The subtracted number from the product cannot" +
                    " exceed the number of units of the product.");
            }
            var baseProduct = (T) product.MemberwiseClone();
            baseProduct.ProductUnitNumber -= number;
            return baseProduct;
        }

        /// <summary>
        /// Getting basic information about the product when converting it.
        /// </summary>
        /// <typeparam name="T">The resulting type.</typeparam>
        /// <typeparam name="K">The type to convert.</typeparam>
        /// <param name="product">The product being converted.</param>
        /// <returns></returns>
        private protected static T GetBaseConvertedProduct<T, K>(K product)
                where T : Product, new()
                where K : Product
        {
            var result = new T() { _productInfo = product._productInfo };
            return result;
        }



    }
}
