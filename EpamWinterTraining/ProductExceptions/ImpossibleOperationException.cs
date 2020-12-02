using System;

namespace EpamWinterTraining.ProductExceptions
{
    /// <summary>
    /// Represents an exception that occurs during erroneous operations with products.
    /// </summary>
    public class ImpossibleOperationException : Exception
    {
        
        public ImpossibleOperationException(string message) : base(message)
        { }

    }
}
