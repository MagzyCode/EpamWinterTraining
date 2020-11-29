using EpamWinterTraining.Products.ProductInformation;
using System;

namespace EpamWinterTraining.Products
{
    public abstract class Product : IProduct
    {
        //private string _title;
        //private int _productUnitNumber;
        //private int _markup;
        //private double _purchasePrice;

        private protected ProductInfo _productInfo;

        protected Product()
        { }
        public Product(ProductInfo productInfo)
        {
            Title = productInfo.Title;
            Markup = productInfo.Markup;
            PurchasePrice = productInfo.PurchasePrice;
            ProductUnitNumber = productInfo.ProductUnitNumber;
        }

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
            //if (obj == null || GetType() != obj.GetType())
            //{
            //    return false;
            //}
            //var product = obj as Product;
            //var result = _productInfo == product._productInfo;
            //return result;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, ProductUnitNumber, Markup, PurchasePrice);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public double GetSingleProductPrice()
        {
            return (PurchasePrice * Markup);
        }

        public double GetTotalProductPrice()
        {
            return (GetSingleProductPrice() * ProductUnitNumber);
        }

        public static explicit operator int(Product product)
        {
            var result = (int)(product.PurchasePrice * product.Markup) * 100;
            return result;
        }

        public static explicit operator double(Product product)
        {
            var result = Math.Round((product.PurchasePrice * product.Markup), 2);
            return result;
        }

        private protected static ProductInfo GetAddition(Product left, Product right)
        {
            if (left.Title != right.Title)
            {
                // вызываем собственное исключение
                // throw new System.Exception();
            }
            var count = left.ProductUnitNumber + right.ProductUnitNumber;
            var markup = (left.Markup * left.ProductUnitNumber +
                right.Markup * right.ProductUnitNumber) / count;
            var price = (left.PurchasePrice * left.ProductUnitNumber +
                right.PurchasePrice * right.ProductUnitNumber) / count;
            var productInfo = new ProductInfo(left.Title, markup, price, count);

            return productInfo;
        }

        private protected static T GetSubtraction<T>(T product, int number) where T : Product
        {
            if (product.ProductUnitNumber < number)
            {
                // вызов соответсвествующего исключения
            }
            var baseProduct = (T) product.MemberwiseClone();
            baseProduct.ProductUnitNumber -= number;
            return baseProduct;
        }

        private protected static T GetBaseConvertedProduct<T, K>(K product)
                where T : Product, new()
                where K : Product
        {
            var result = new T() { _productInfo = product._productInfo };
            return result;
        }



    }
}
