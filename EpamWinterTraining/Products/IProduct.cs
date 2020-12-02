namespace EpamWinterTraining.Products
{
    /// <summary>
    /// Interface that describes the required functionality for the product type.
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// Getting the cost per unit of production, taking into account the markup.
        /// </summary>
        /// <returns></returns>
        double GetSingleProductPrice();

        /// <summary>
        /// Getting the total cost of products, including margins and the number of units.
        /// </summary>
        /// <returns></returns>
        double GetTotalProductPrice();
    }
}
