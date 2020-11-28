namespace EpamWinterTraining.Products
{
    public abstract class ProductionProduct : Product
    {
        private int _energyValue;

        public ProductionProduct(string title, int markup, double purchasePrice, int energyValue, int count):
            base(title, markup, purchasePrice, count)
        {
            EnergyValue = energyValue;
        }

        public int EnergyValue
        {
            get
            {
                return _energyValue;
            }
            set
            {
                _energyValue = value;
            }
        }
    }
}
