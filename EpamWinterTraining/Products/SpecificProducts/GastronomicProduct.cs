namespace EpamWinterTraining.Products.SpecificProducts
{
    public class GastronomicProduct : ProductionProduct
    {

        public GastronomicProduct(string title, int markup, double purchasePrice, int energyValue, int count = 1) :
            base(title, markup, purchasePrice, energyValue, count)
        { }
    }
}
