namespace EpamWinterTraining.Products
{
    public abstract class Product : IProduct
    {
        private string _title;
        private int _productUnitNumber;
        private int _markup;
        private double _purchasePrice;

        protected Product()
        { }
        public Product(string title, int markup, double purchasePrice, int count = 1)
        {
            Title = title;
            Markup = markup;
            PurchasePrice = purchasePrice;
            ProductUnitNumber = count;
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        public int ProductUnitNumber
        {
            get
            {
                return _productUnitNumber;
            }
            private set
            {
                _productUnitNumber = value;
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
                _markup = value;
            }
        }

        public double PurchasePrice
        {
            get
            {
                return _purchasePrice;
            }
            set
            {
                _purchasePrice = value;
            }
        }

        public double GetSingleProductPrice()
        {
            var price = PurchasePrice * Markup;
            return price;
        }

        public double GetTotalProductPrice()
        {
            var price = GetSingleProductPrice() * ProductUnitNumber;
            return price;
        }
        //public static T GetAdditionOfProducts<T>(T first, T second) where T : Product, new()
        //{
        //    if (first.Title != second.Title)
        //    {
        //        return null;
        //    }

        //    var count = first.ProductUnitNumber + second.ProductUnitNumber;
        //    var markup = (first.ProductUnitNumber * first.ProductUnitNumber +
        //        second.ProductUnitNumber * second.ProductUnitNumber) / count;
        //    var price = (first.PurchasePrice * first.ProductUnitNumber +
        //        second.PurchasePrice * second.ProductUnitNumber) / count;

        //    T newProduct = new T()
        //    {
        //        ProductUnitNumber = count,
        //        Markup = markup,
        //        PurchasePrice = price,
        //        Title = first.Title
        //    };
        //    return newProduct;
        //}
        
        //public static T GetSubtraction<T>(T product, int number) where T : Product, new()
        //{
        //    if (product.ProductUnitNumber < number)
        //    {
        //        throw new System.Exception("ASS");
        //    }

        //    T newProduct = new T() {
        //        Title = product.Title,
        //        Markup = p
        //    };
        //}
    }
}
