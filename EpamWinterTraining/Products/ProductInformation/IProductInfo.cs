namespace EpamWinterTraining.Products.ProductInformation
{
    /// <summary>
    /// Interface that describes the structure of the standard product information type.
    /// </summary>
    public interface IProductInfo
    {
        /// <summary>
        /// Name of produce.
        /// </summary>
        string Title { get; }
        /// <summary>
        /// The number of units of the product.
        /// </summary>
        int ProductUnitNumber { get; }
        /// <summary>
        /// The markup on the product.
        /// </summary>
        int Markup { get; }
        /// <summary>
        /// Purchase price for the product.
        /// </summary>
        double PurchasePrice { get; }
    }
}
