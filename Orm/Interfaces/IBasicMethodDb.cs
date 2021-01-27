using System.Collections.Generic;

namespace Orm.Interfaces
{
    /// <summary>
    /// Interface describes the IBasicMethodDb.
    /// </summary>
    public interface IBasicMethodDb<T>
    {
        /// <summary>
        /// Method read collection objects table from database.
        /// </summary>
        /// <returns>Collection<T> objects.</returns>
        public List<T> Read();

        /// <summary>
        /// Method add object to database.
        /// </summary>
        /// <param name="obj">Object to add to database tables.</param>
        public void Create(T obj);

        /// <summary>
        /// Method update object to database.
        /// </summary>
        /// <param name="id">Id object.</param>
        /// <param name="obj">Object to update to database.</param>
        public void Update(int id, T obj);

        /// <summary>
        /// Method delete object from database.
        /// </summary>
        /// <param name="id">Id object.</param>
        public void Delete(int id);
    }
}
