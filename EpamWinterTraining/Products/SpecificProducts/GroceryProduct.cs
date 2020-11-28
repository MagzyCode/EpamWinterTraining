namespace EpamWinterTraining.Products.SpecificProducts
{
    public class GroceryProduct : ProductionProduct
    {
        public GroceryProduct(string title, int markup, double purchasePrice, int energyValue, int count = 1) :
            base(title, markup, purchasePrice, energyValue, count)
        { }
    }
}
