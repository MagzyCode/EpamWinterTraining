using EpamWinterTraining.Products.ProductInformation;

namespace EpamWinterTraining.Products.SpecificProducts
{
    public class GastronomicProduct : ProductionProduct
    { 
        public GastronomicProduct() : base(default, default)
        { }

        /// <summary>
        /// Initializes an object of the type GastronomicProduct.
        /// </summary>
        /// <param name="productInfo">Basic information about the product.</param>
        /// <param name="energyValue">Energy value of the product.</param>
        public GastronomicProduct(ProductInfo productInfo, int energyValue) :
                    base(productInfo, energyValue)
        { }


        /// <summary>
        /// Getting the addition of two products by counting the main properties, 
        /// taking into account the units of production of each product.
        /// </summary>
        /// <param name="left">Left operator.</param>
        /// <param name="right">Right operator.</param>
        /// <returns>Returns a product based on a tagline.</returns>
        public static GastronomicProduct operator +(GastronomicProduct left, GastronomicProduct right)
        {
            ProductInfo info = GetAddition(left, right);
            int energyValue = GetEnergyValue(left, right);
            var product = new GastronomicProduct(info, energyValue);
            return product;
        }

        /// <summary>
        /// Getting the difference between the product and the number. 
        /// A number is the number of units of deductible output.
        /// </summary>
        /// <param name="left">Left operator.</param>
        /// <param name="right">Right operator.</param>
        /// <returns>Returns the product with the changed number of units.</returns>
        public static GastronomicProduct operator -(GastronomicProduct left, int right)
        {
            var result = GetSubtraction(left, right);
            return result;
        }

        public static explicit operator BiochemicalProduct(GastronomicProduct product)
        {
            var result = GetBaseConvertedProduct<BiochemicalProduct, GastronomicProduct>(product);
            return result;
        }

        public static explicit operator GroceryProduct(GastronomicProduct product)
        {
            var result = GetActualConvertedProduct<GroceryProduct, GastronomicProduct>(product);
            return result;
        }

        public static explicit operator HouseholdProduct(GastronomicProduct product)
        {
            var result = GetBaseConvertedProduct<HouseholdProduct, GastronomicProduct>(product);
            return result;
        }
    }
}
