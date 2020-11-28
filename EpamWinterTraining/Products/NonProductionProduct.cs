using EpamWinterTraining.Products.ProductRadiation;

namespace EpamWinterTraining.Products
{
    public abstract class NonProductionProduct : Product
    {
        private RadiationGroup _radiationGroup;
        public NonProductionProduct(string title, int markup, double purchasePrice, int count, RadiationGroup group):
            base(title, markup, purchasePrice, count)
        { }

        public RadiationGroup RadiationGroup
        {
            get
            {
                return _radiationGroup;
            }
            set
            {
                _radiationGroup = value;
            }
        }


    }
}
