using EpamWinterTraining.Products.ProductInformation;

namespace EpamWinterTraining.Products.SpecificProducts
{
    public class GroceryProduct : ProductionProduct
    {
        public GroceryProduct() : base()
        { }

        /// <summary>
        /// Initializes an object of the type GroceryProduct.
        /// </summary>
        /// <param name="productInfo">Basic information about the product.</param>
        /// <param name="energyValue">Energy value of the product.</param>
        public GroceryProduct(ProductInfo productInfo, int energyValue) :
                    base(productInfo, energyValue)
        { }


        /// <summary>
        /// Getting the addition of two products by counting the main properties, 
        /// taking into account the units of production of each product.
        /// </summary>
        /// <param name="left">Left operator.</param>
        /// <param name="right">Right operator.</param>
        /// <returns>Returns a product based on a tagline.</returns>
        public static GroceryProduct operator +(GroceryProduct left, GroceryProduct right)
        {
            ProductInfo info = GetAddition(left, right);
            int energyValue = GetEnergyValue(left, right);
            var product = new GroceryProduct(info, energyValue);
            return product;
        }

        /// <summary>
        /// Getting the difference between the product and the number. 
        /// A number is the number of units of deductible output.
        /// </summary>
        /// <param name="left">Left operator.</param>
        /// <param name="right">Right operator.</param>
        /// <returns>Returns the product with the changed number of units.</returns>
        public static GroceryProduct operator -(GroceryProduct left, int right)
        {
            var result = GetSubtraction(left, right);
            return result;
        }

        public static explicit operator BiochemicalProduct(GroceryProduct product)
        {
            var result = GetBaseConvertedProduct<BiochemicalProduct, GroceryProduct>(product);
            return result;
        }

        public static explicit operator GastronomicProduct(GroceryProduct product)
        {
            var result = GetActualConvertedProduct<GastronomicProduct, GroceryProduct>(product);
            return result;
        }

        public static explicit operator HouseholdProduct(GroceryProduct product)
        {
            var result = GetBaseConvertedProduct<HouseholdProduct, GroceryProduct>(product);
            return result;
        }
    }
}
