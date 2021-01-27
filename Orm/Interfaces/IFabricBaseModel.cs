using Orm.Creators;

namespace Orm.Interfaces
{
    public interface IFabricBaseModel
    {
        /// <summary>
        /// Method read collection objects table from database.
        /// </summary>
        /// <returns>Object BaseModel.</returns>
        public abstract BaseModel Create();
    }
}
