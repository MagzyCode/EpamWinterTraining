using Orm.Interfaces;

namespace Orm.Creators
{
    /// <summary>
    /// Class describes the Base Model.
    /// </summary>
    public abstract class BaseModel : IBaseModel
    {
        /// <summary>
        /// The property stores information about the Id of the Base Model.
        /// </summary>
        public int Id { get; set; }
    }
}
