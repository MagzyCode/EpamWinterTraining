namespace EpamWinterTraining.Products
{
    /// <summary>
    /// Interface for the main implemented methods for any bakery product.
    /// </summary>
    public interface IProduct
    {
        int GetProductCalorific();
        double GetProductPrice();
        int GetProductWeight();
    }
}
