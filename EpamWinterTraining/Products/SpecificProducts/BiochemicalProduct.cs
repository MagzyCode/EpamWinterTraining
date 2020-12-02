using EpamWinterTraining.Products.ProductInformation;
using EpamWinterTraining.Products.ProductRadiation;

namespace EpamWinterTraining.Products.SpecificProducts
{
    public class BiochemicalProduct : NonProductionProduct
    {
        public BiochemicalProduct() : base()
        { }

        /// <summary>
        /// Initializes an object of the type BiochemicalProduct.
        /// </summary>
        /// <param name="productInfo">Basic information about the product.</param>
        /// <param name="group">Radiation group of the product.</param>
        public BiochemicalProduct(ProductInfo productInfo, RadiationGroup group) :
            base(productInfo, group)
        { }

        /// <summary>
        /// Getting the addition of two products by counting the main properties, 
        /// taking into account the units of production of each product.
        /// </summary>
        /// <param name="left">Left operator.</param>
        /// <param name="right">Right operator.</param>
        /// <returns>Returns a product based on a tagline.</returns>
        public static BiochemicalProduct operator +(BiochemicalProduct left, BiochemicalProduct right)
        {
            ProductInfo info = GetAddition(left, right);
            RadiationGroup group = GetRadiationGroup(left, right);
            var product = new BiochemicalProduct(info, group);
            return product;
        }

        /// <summary>
        /// Getting the difference between the product and the number. 
        /// A number is the number of units of deductible output.
        /// </summary>
        /// <param name="left">Left operator.</param>
        /// <param name="right">Right operator.</param>
        /// <returns>Returns the product with the changed number of units.</returns>
        public static BiochemicalProduct operator -(BiochemicalProduct left, int right)
        {
            var result = GetSubtraction(left, right);
            return result;
        }

        public static explicit operator GastronomicProduct(BiochemicalProduct product)
        {
            var result = GetBaseConvertedProduct<GastronomicProduct, BiochemicalProduct>(product);
            return result;
        }

        public static explicit operator GroceryProduct(BiochemicalProduct product)
        {
            var result = GetBaseConvertedProduct<GroceryProduct, BiochemicalProduct>(product);
            return result;
        }

        public static explicit operator HouseholdProduct(BiochemicalProduct product)
        {
            var result = GetActualConvertedProduct<HouseholdProduct, BiochemicalProduct>(product);
            return result;
        }
    }
}
