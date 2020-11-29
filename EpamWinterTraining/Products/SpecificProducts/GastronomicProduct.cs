using EpamWinterTraining.Products.ProductInformation;

namespace EpamWinterTraining.Products.SpecificProducts
{
    public class GastronomicProduct : ProductionProduct
    { 
        public GastronomicProduct() : base(default, default)
        { }

        public GastronomicProduct(ProductInfo productInfo, int energyValue) :
                    base(productInfo, energyValue)
        { }

        public static GastronomicProduct operator +(GastronomicProduct left, GastronomicProduct right)
        {
            ProductInfo info = GetAddition(left, right);
            int energyValue = GetEnergyValue(left, right);
            var product = new GastronomicProduct(info, energyValue);
            return product;
        }

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
