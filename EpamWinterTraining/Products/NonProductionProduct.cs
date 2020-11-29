using EpamWinterTraining.Products.ProductInformation;
using EpamWinterTraining.Products.ProductRadiation;

namespace EpamWinterTraining.Products
{
    public abstract class NonProductionProduct : Product
    {
        public NonProductionProduct(ProductInfo productInfo, RadiationGroup group):
            base(productInfo)
        {
            RadiationGroup = group;
        }

        public RadiationGroup RadiationGroup { get; set; }

        private protected static RadiationGroup GetRadiationGroup(NonProductionProduct left, NonProductionProduct right)
        {
            return (left.RadiationGroup > right.RadiationGroup) ? left.RadiationGroup : right.RadiationGroup;
        }

        private protected static T GetActualConvertedProduct<T, K>(K product) 
            where T : NonProductionProduct, new()
            where K : NonProductionProduct
        {
            // var baseInfo = GetBaseConvertedProduct<T, K>(product);
            var result = new T()
            {
                _productInfo = product._productInfo,
                RadiationGroup = product.RadiationGroup
            };
            return result;
        }
    }
}
