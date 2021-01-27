using Orm.Interfaces;

namespace Orm.Creators
{
    /// <summary>
    /// Class describes the fabric base model.
    /// </summary>
    public abstract class FabricBaseModel : IFabricBaseModel
    {
        /// <summary>
        /// Method create BaseModel object .
        /// </summary>
        /// <returns>Abstract BaseModel object.</returns>
        public abstract BaseModel Create();
    }
}
