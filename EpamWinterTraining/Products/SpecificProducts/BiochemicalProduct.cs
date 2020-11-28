using EpamWinterTraining.Products.ProductRadiation;

namespace EpamWinterTraining.Products.SpecificProducts
{
    public class BiochemicalProduct : NonProductionProduct
    {
        public BiochemicalProduct(string title, int markup, double purchasePrice, int count, RadiationGroup group) :
            base(title, markup, purchasePrice, count, group)
        { }

        //public static BiochemicalProduct operator +(BiochemicalProduct left, BiochemicalProduct right)
        //{
        //    if (left.Title != right.Title)
        //    {
        //        throw new System.Exception();
        //    }

        //    var count = left.ProductUnitNumber + right.ProductUnitNumber;
        //    var markup = (left.ProductUnitNumber * left.ProductUnitNumber +
        //        right.ProductUnitNumber * right.ProductUnitNumber) / count;
        //    var price = (left.PurchasePrice * left.ProductUnitNumber +
        //        right.PurchasePrice * right.ProductUnitNumber) / count;

        //    // var
        //}
    }
}
