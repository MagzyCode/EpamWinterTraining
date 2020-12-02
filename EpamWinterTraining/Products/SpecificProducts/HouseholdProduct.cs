using EpamWinterTraining.Products.ProductInformation;
using EpamWinterTraining.Products.ProductRadiation;

namespace EpamWinterTraining.Products.SpecificProducts
{
    public class HouseholdProduct : NonProductionProduct
    {
        public HouseholdProduct() : base(default, default)
        { }

        /// <summary>
        /// Initializes an object of the type HouseholdProduct.
        /// </summary>
        /// <param name="productInfo">Basic information about the product.</param>
        /// <param name="group">Radiation group of the product.</param>
        public HouseholdProduct(ProductInfo productInfo, RadiationGroup group = RadiationGroup.E) :
            base(productInfo, group)
        { }

        /// <summary>
        /// Getting the addition of two products by counting the main properties, 
        /// taking into account the units of production of each product.
        /// </summary>
        /// <param name="left">Left operator.</param>
        /// <param name="right">Right operator.</param>
        /// <returns>Returns a product based on a tagline.</returns>
        public static HouseholdProduct operator +(HouseholdProduct left, HouseholdProduct right)
        {
            ProductInfo info = GetAddition(left, right);
            RadiationGroup group = GetRadiationGroup(left, right);
            var product = new HouseholdProduct(info, group);
            return product;
        }

        /// <summary>
        /// Getting the difference between the product and the number. 
        /// A number is the number of units of deductible output.
        /// </summary>
        /// <param name="left">Left operator.</param>
        /// <param name="right">Right operator.</param>
        /// <returns>Returns the product with the changed number of units.</returns>
        public static HouseholdProduct operator -(HouseholdProduct left, int right)
        {
            var result = GetSubtraction(left, right);
            return result;
        }

        public static explicit operator BiochemicalProduct(HouseholdProduct product)
        {
            var result = GetActualConvertedProduct<BiochemicalProduct, HouseholdProduct>(product);
            return result;
        }

        public static explicit operator GastronomicProduct(HouseholdProduct product)
        {
            var result = GetBaseConvertedProduct<GastronomicProduct, HouseholdProduct>(product);
            return result;
        }

        public static explicit operator GroceryProduct(HouseholdProduct product)
        {
            var result = GetBaseConvertedProduct<GroceryProduct, HouseholdProduct>(product);
            return result;
        }
    }
}
