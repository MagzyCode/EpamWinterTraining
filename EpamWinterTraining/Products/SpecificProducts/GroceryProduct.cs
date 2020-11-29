using EpamWinterTraining.Products.ProductInformation;

namespace EpamWinterTraining.Products.SpecificProducts
{
    public class GroceryProduct : ProductionProduct
    {
        public GroceryProduct() : base(default, default)
        { }

        public GroceryProduct(ProductInfo productInfo, int energyValue) :
                    base(productInfo, energyValue)
        { }

        public static GroceryProduct operator +(GroceryProduct left, GroceryProduct right)
        {
            ProductInfo info = GetAddition(left, right);
            int energyValue = GetEnergyValue(left, right);
            var product = new GroceryProduct(info, energyValue);
            return product;
        }

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
