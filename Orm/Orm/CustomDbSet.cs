using Orm.Creators;
using Orm.CRUD;
using Orm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orm.Orm
{

    /// <summary>
    /// Class describes the CustomDbSet.
    /// </summary>
    public class CustomDbSet<T> : ICustomDbSet<T> where T : BaseModel, new()
    {
        /// <summary>
        /// The field stores information about the instance CustomDbSet<T>.
        /// </summary>
        private static CustomDbSet<T> _instance;

        /// <summary>
        /// The field stores information about fabric base model creator.
        /// </summary>
        private readonly string _tableName;

        /// <summary>
        /// The field stores information about BasicMethodDb<T>.
        /// </summary>
        private readonly BasicMethodDb<T> _basicMethodDb;

        /// <summary>
        /// The constructor initializes the class object.
        /// </summary>
        /// <param name="connectionString">Database connection string.</param>
        /// <param name="tableName">Table name in database.</param>
        /// <param name="fabricBaseModel">Fabric base model creator.</param>
        private CustomDbSet(string connectionString, string tableName, FabricBaseModel fabricBaseModel)
        {
            _tableName = tableName;
            _basicMethodDb = BasicMethodDb<T>.GetInstance(connectionString, _tableName, fabricBaseModel);
            Collection = GetCollection();
        }

        /// <summary>
        /// Method get instance BasicMethodDb object.
        /// </summary>
        /// <param name="connectionString">Database connection string.</param>
        /// <param name="tableName">Table name in database.</param>
        /// <param name="fabricBaseModel">Fabric base model creator.</param>
        /// <returns>Instance BasicMethodDb<T>.</returns>
        public static CustomDbSet<T> GetInstance(string connectionString, string tableName, FabricBaseModel fabricBaseModel)
        {
            if (_instance == null)
            {
                _instance = new CustomDbSet<T>(connectionString, tableName, fabricBaseModel);
            }

            return _instance;
        }

        /// <summary>
        /// The property stores information about list objects.
        /// </summary>
        public List<T> Collection { get; set; }

        /// <summary>
        /// Method read collection objects table from database.
        /// </summary>
        /// <returns>Collection<T> objects.</returns>
        public List<T> GetCollection()
        {
            Collection = _basicMethodDb.Read();

            return Collection;
        }

        /// <summary>
        /// Method add list objects to database.
        /// </summary>
        /// <param name="obj">Object to add to database tables.</param>
        public void Add(List<T> collection)
        {
            foreach (T item in Collection)
            {
                collection = collection.Where(obj => !obj.Equals(item)).Select(item => item).ToList();
            }

            foreach (var item in collection)
            {
                _basicMethodDb.Create(item);
            }
        }

        /// <summary>
        /// Method add object to database.
        /// </summary>
        /// <param name="obj">Object to add to database tables.</param>
        public void Add(T addObj)
        {
            if (addObj != Collection.Select(item => item))
            {
                _basicMethodDb.Create(addObj);
            }
        }

        /// <summary>
        /// Method update object to database.
        /// </summary>
        /// <param name="id">Id object.</param>
        /// <param name="obj">Object to update to database.</param>
        public void Сhange(int id, T item)
        {
            _basicMethodDb.Update(id, item);
        }

        /// <summary>
        /// Method delete object from database.
        /// </summary>
        /// <param name="id">Id object.</param>
        public void Remove(int id)
        {
            _basicMethodDb.Delete(id);
        }
    }
}
