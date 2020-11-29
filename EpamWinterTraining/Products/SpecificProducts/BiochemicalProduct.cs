using EpamWinterTraining.Products.ProductInformation;
using EpamWinterTraining.Products.ProductRadiation;

namespace EpamWinterTraining.Products.SpecificProducts
{
    public class BiochemicalProduct : NonProductionProduct
    {
        public BiochemicalProduct() : base(default, default) 
        { }

        public BiochemicalProduct(ProductInfo productInfo, RadiationGroup group) :
            base(productInfo, group)
        { }

        public static BiochemicalProduct operator +(BiochemicalProduct left, BiochemicalProduct right)
        {
            ProductInfo info = GetAddition(left, right);
            RadiationGroup group = GetRadiationGroup(left, right);
            var product = new BiochemicalProduct(info, group);
            return product;
        }

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
