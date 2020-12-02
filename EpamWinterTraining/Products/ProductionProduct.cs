using EpamWinterTraining.Products.ProductInformation;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpamWinterTraining.Products
{
    public abstract class ProductionProduct : Product
    {
        private protected ProductionProduct() : base()
        { }

        /// <summary>
        /// Initializes an object of the type GroceryProduct.
        /// </summary>
        /// <param name="productInfo">Basic information about the product.</param>
        /// <param name="energyValue">Energy value of the product.</param>
        public ProductionProduct(ProductInfo productInfo, int energyValue):
            base(productInfo)
        {
            EnergyValue = energyValue;
        }

        /// <summary>
        /// Energy value of the product.
        /// </summary>
        [Range(0, int.MaxValue, ErrorMessage = "The product energy value must not be less than 0.")]
        public int EnergyValue { get; set; }

        /// <summary>
        /// Getting the total value of goods based on the quantity of each of them.
        /// </summary>
        /// <param name="left">Left operator.</param>
        /// <param name="right">Right operator.</param>
        /// <returns></returns>
        private protected static int GetEnergyValue(ProductionProduct left, ProductionProduct right)
        {
            var energyValue = (left.EnergyValue * left.ProductUnitNumber +
                right.EnergyValue * right.ProductUnitNumber) / (left.ProductUnitNumber + right.ProductUnitNumber);
            return energyValue;
        }


        /// <summary>
        /// Converts the type's descendant NonProductionProduct to an heir of the same type.
        /// </summary>
        /// <typeparam name="T">The resulting type.</typeparam>
        /// <typeparam name="K">The type to convert</typeparam>
        /// <param name="product">The product being converted.</param>
        /// <returns>The converted product.</returns>
        private protected static T GetActualConvertedProduct<T, K>(K product)
            where T : ProductionProduct, new()
            where K : ProductionProduct
        {
            var result = new T()
            {
                _productInfo = product._productInfo,
                EnergyValue = product.EnergyValue
            };
            return result;
        }

        public override bool Equals(object obj)
        {
            return (base.Equals(obj) && (obj as ProductionProduct).EnergyValue == EnergyValue);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_productInfo, EnergyValue);
        }
    }
}
