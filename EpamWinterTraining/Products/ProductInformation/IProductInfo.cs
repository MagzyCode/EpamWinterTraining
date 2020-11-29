namespace EpamWinterTraining.Products.ProductInformation
{
    public interface IProductInfo
    {
        string Title { get; }
        int ProductUnitNumber { get; }
        int Markup { get; }
        double PurchasePrice { get; }
    }
}
