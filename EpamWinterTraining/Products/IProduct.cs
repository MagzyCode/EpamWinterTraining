using System;
using System.Collections.Generic;
using System.Text;

namespace EpamWinterTraining.Products
{
    public interface IProduct
    {
        double GetSingleProductPrice();
        double GetTotalProductPrice();
    }
}
