using EpamWinterTraining.Products.ProductInformation;
using EpamWinterTraining.Products.ProductRadiation;
using System;

namespace EpamWinterTraining.Products
{
    public abstract class NonProductionProduct : Product
    {
        private protected NonProductionProduct() : base()
        { }

        /// <summary>
        /// Initializes an object of the type BiochemicalProduct.
        /// </summary>
        /// <param name="productInfo">Basic information about the product.</param>
        /// <param name="group">Radiation group of the product.</param>
        public NonProductionProduct(ProductInfo productInfo, RadiationGroup group):
            base(productInfo)
        {
            RadiationGroup = group;
        }

        /// <summary>
        /// Radiation group of the product.
        /// </summary>
        public RadiationGroup RadiationGroup { get; set; }

        /// <summary>
        /// Getting a certain radiation group during an operation with heirs of this type.
        /// </summary>
        /// <param name="left">Left operator.</param>
        /// <param name="right">Right operator.</param>
        /// <returns></returns>
        private protected static RadiationGroup GetRadiationGroup(NonProductionProduct left, NonProductionProduct right)
        {
            return (left.RadiationGroup > right.RadiationGroup) ? left.RadiationGroup : right.RadiationGroup;
        }

        /// <summary>
        /// Converts the type's descendant NonProductionProduct to an heir of the same type.
        /// </summary>
        /// <typeparam name="T">The resulting type.</typeparam>
        /// <typeparam name="K">The type to convert.</typeparam>
        /// <param name="product">The product being converted.</param>
        /// <returns>The converted product.</returns>
        private protected static T GetActualConvertedProduct<T, K>(K product) 
            where T : NonProductionProduct, new()
            where K : NonProductionProduct
        {
            var result = new T()
            {
                _productInfo = product._productInfo,
                RadiationGroup = product.RadiationGroup
            };
            return result;
        }

        public override bool Equals(object obj)
        {
            return (base.Equals(obj) && (obj as NonProductionProduct).RadiationGroup == RadiationGroup);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_productInfo, RadiationGroup);
        }
    }
}
