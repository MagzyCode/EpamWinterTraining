using EpamWinterTraining.Products.ProductInformation;
using System.ComponentModel.DataAnnotations;

namespace EpamWinterTraining.Products
{
    public abstract class ProductionProduct : Product
    {
        public ProductionProduct(ProductInfo productInfo, int energyValue):
            base(productInfo)
        {
            EnergyValue = energyValue;
        }

        [Range(0, int.MaxValue, ErrorMessage = "The product energy value must not be less than 0.")]
        public int EnergyValue { get; set; }

        private protected static int GetEnergyValue(ProductionProduct left, ProductionProduct right)
        {
            var energyValue = (left.EnergyValue * left.ProductUnitNumber +
                right.EnergyValue * right.ProductUnitNumber) / (left.ProductUnitNumber + right.ProductUnitNumber);
            return energyValue;
        }

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
    }
}
