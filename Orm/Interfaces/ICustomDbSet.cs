using System;
using System.Collections.Generic;
using System.Text;

namespace Orm.Interfaces
{
    /// <summary>
    /// Interface describes the ICustomDbSet.
    /// </summary>
    public interface ICustomDbSet<T>
    {
        /// <summary>
        /// Method read collection objects table from database.
        /// </summary>
        /// <returns>Collection<T> objects.</returns>
        public List<T> GetCollection();

        /// <summary>
        /// Method add list objects to database.
        /// </summary>
        /// <param name="obj">Object to add to database tables.</param>
        public void Add(List<T> collection);

        /// <summary>
        /// Method add object to database.
        /// </summary>
        /// <param name="obj">Object to add to database tables.</param>
        public void Add(T addObj);

        /// <summary>
        /// Method update object to database.
        /// </summary>
        /// <param name="id">Id object.</param>
        /// <param name="obj">Object to update to database.</param>
        public void Сhange(int id, T item);

        /// <summary>
        /// Method delete object from database.
        /// </summary>
        /// <param name="id">Id object.</param>
        public void Remove(int id);
    }
}
