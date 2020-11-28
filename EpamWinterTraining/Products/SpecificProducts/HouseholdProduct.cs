using EpamWinterTraining.Products.ProductRadiation;

namespace EpamWinterTraining.Products.SpecificProducts
{
    public class HouseholdProduct : NonProductionProduct
    {
        public HouseholdProduct(string title, int markup, double purchasePrice, int count = 1, RadiationGroup group = RadiationGroup.E) :
            base(title, markup, purchasePrice, count, group)
        { }
    }
}
