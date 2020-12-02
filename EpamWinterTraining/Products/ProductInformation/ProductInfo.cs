using System;

namespace EpamWinterTraining.Products.ProductInformation
{
    /// <summary>
    /// A structure that represents basic information about the product.
    /// </summary>
    public struct ProductInfo : IProductInfo
    {
        /// <summary>
        /// Initializes the product information object.
        /// </summary>
        /// <param name="title">Name of produce.</param>
        /// <param name="markup">The markup on the product.</param>
        /// <param name="purchasePrice">Purchase price for the product.</param>
        /// <param name="count">The number of units of the product.</param>
        public ProductInfo(string title, int markup, double purchasePrice, int count)
        {
            Title = title;
            Markup = markup;
            PurchasePrice = purchasePrice;
            ProductUnitNumber = count;
        }

        /// <summary>
        /// Name of produce.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The number of units of the product.
        /// </summary>
        public int ProductUnitNumber { get; set; }

        /// <summary>
        /// The markup on the product.
        /// </summary>
        public int Markup { get; set; }

        /// <summary>
        /// Purchase price for the product.
        /// </summary>
        public double PurchasePrice { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ProductInfo info &&
                   Title == info.Title &&
                   ProductUnitNumber == info.ProductUnitNumber &&
                   Markup == info.Markup &&
                   PurchasePrice == info.PurchasePrice;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Title, ProductUnitNumber, Markup, PurchasePrice);
        }

        /// <summary>
        /// An equality comparison operation. It is based on equality of structure properties.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Returns true if the values of all properties match. In the opposite case, false.</returns>
        public static bool operator == (ProductInfo left, ProductInfo right)
        {
            return (left.Markup == right.Markup) &&
                (left.ProductUnitNumber == right.ProductUnitNumber) &&
                (left.PurchasePrice == right.PurchasePrice) &&
                (left.Title == right.Title);
        }

        /// <summary>
        /// The inequality comparison operation is based on the equality of structure properties.
        /// </summary>
        /// <param name="left">Left operand.</param>
        /// <param name="right">Right operand.</param>
        /// <returns>Returns true if the values of any properties doesn't match. In the opposite case, false.</returns>
        public static bool operator !=(ProductInfo left, ProductInfo right)
        {
            return !(left == right);
        }
    }
}
