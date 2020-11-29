using EpamWinterTraining.Products.ProductInformation;
using EpamWinterTraining.Products.ProductRadiation;

namespace EpamWinterTraining.Products.SpecificProducts
{
    public class HouseholdProduct : NonProductionProduct
    {
        public HouseholdProduct() : base(default, default)
        { }

        public HouseholdProduct(ProductInfo productInfo, RadiationGroup group = RadiationGroup.E) :
            base(productInfo, group)
        { }

        public static HouseholdProduct operator +(HouseholdProduct left, HouseholdProduct right)
        {
            ProductInfo info = GetAddition(left, right);
            RadiationGroup group = GetRadiationGroup(left, right);
            var product = new HouseholdProduct(info, group);
            return product;
        }

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
