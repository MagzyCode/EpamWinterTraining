using System;
using System.ComponentModel.DataAnnotations;

namespace EpamWinterTraining.Products.ProductInformation
{
    public struct ProductInfo : IProductInfo
    {
        public ProductInfo(string title, int markup, double purchasePrice, int count)
        {
            Title = title;
            Markup = markup;
            PurchasePrice = purchasePrice;
            ProductUnitNumber = count;
        }

        [Required(ErrorMessage = "The product name must be initiated.")]
        [MinLength(0, ErrorMessage = "The product name must not be less than 0.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The product unit number must be initiated.")]
        [Range(0, int.MaxValue, ErrorMessage = "The product name must not be less than 0.")]
        public int ProductUnitNumber { get; set; }

        [Required(ErrorMessage = "The product markup must be initiated.")]
        [Range(100, int.MaxValue, ErrorMessage = "The product name must not be less than 100%.")]
        public int Markup { get; set; }

        [Required(ErrorMessage = "The product purchase price must be initiated.")]
        [Range(0, int.MaxValue, ErrorMessage = "The product name must not be less than 0.")]
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

        public static bool operator == (ProductInfo left, ProductInfo right)
        {
            return (left.Markup == right.Markup) &&
                (left.ProductUnitNumber == right.ProductUnitNumber) &&
                (left.PurchasePrice == right.PurchasePrice) &&
                (left.Title == right.Title);
        }

        public static bool operator !=(ProductInfo left, ProductInfo right)
        {
            return !(left == right);
        }
    }
}
