using Orm.Creators;
using Orm.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace Orm.CRUD
{
    /// <summary>
    /// Class describes the basic methods database.
    /// </summary>
    public class BasicMethodDb<T> : IBasicMethodDb<T> where T : BaseModel, new()
    {
        /// <summary>
        /// The field stores information about the instance BasicMethodDb<T>.
        /// </summary>
        private static BasicMethodDb<T> instance;

        /// <summary>
        /// The field stores information about fabric base model creator.
        /// </summary>
        private readonly FabricBaseModel _fabricBaseModel;

        /// <summary>
        /// The field stores information about table name in database.
        /// </summary>
        private readonly string _tableName;

        /// <summary>
        /// The field stores information about list property object T.
        /// </summary>
        private readonly List<PropertyInfo> _properties;

        /// <summary>
        /// The field stores information about sql connerction.
        /// </summary>
        private readonly SqlConnection _connection;

        /// <summary>
        /// The constructor initializes the class object.
        /// </summary>
        /// <param name="connectionString">Database connection string.</param>
        /// <param name="tableName">Table name in database.</param>
        /// <param name="fabricBaseModel">Fabric base model creator.</param>
        private BasicMethodDb(string connectionString, string tableName, FabricBaseModel fabricBaseModel)
        {
            _properties = new List<PropertyInfo>(typeof(T).GetProperties());
            _connection = new SqlConnection(connectionString);
            _fabricBaseModel = fabricBaseModel;
            _tableName = tableName;
        }

        /// <summary>
        /// Method get instance BasicMethodDb object.
        /// </summary>
        /// <param name="connectionString">Database connection string.</param>
        /// <param name="tableName">Table name in database.</param>
        /// <param name="fabricBaseModel">Fabric base model creator.</param>
        /// <returns>Instance BasicMethodDb<T>.</returns>
        public static BasicMethodDb<T> GetInstance(string connectionString, string tableName, FabricBaseModel fabricBaseModel)
        {
            if (instance == null)
            {
                instance = new BasicMethodDb<T>(connectionString, tableName, fabricBaseModel);
            }

            return instance;
        }

        /// <summary>
        /// Method read collection objects table from database.
        /// </summary>
        /// <returns>Collection<T> objects.</returns>
        public List<T> Read()
        {
            var sqlExpressionString = $"SELECT * FROM {_tableName}";

            var sqlCommand = new SqlCommand(sqlExpressionString, _connection);
            sqlCommand.Parameters.AddWithValue(_tableName, _tableName);
            try
            {
                _connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                var collection = new List<T>();
                var typeOfT = typeof(T);

                var fieldCount = reader.FieldCount;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var obj = _fabricBaseModel.Create();
                        for (int i = 0; i < fieldCount; i++)
                        {
                            var propInfo = typeOfT.GetProperty(reader.GetName(i));
                            propInfo?.SetValue(obj, reader.GetValue(i));
                        }
                        collection.Add((T)obj);
                    }
                }

                _connection.Close();
                return collection;
            }
            catch (Exception)
            {
                throw new Exception("Sql query error.");
            }
        }

        /// <summary>
        /// Method add object to database.
        /// </summary>
        /// <param name="obj">Object to add to database tables.</param>
        public void Create(T obj)
        {
            var sqlExpressionString = $"INSERT INTO [{_tableName}] (";
            var parameterName = new List<string>();

            foreach (var property in _properties) /*typeof(T).GetProperties()*/
            {
                if (property.Name == "Id" || property.PropertyType.BaseType == typeof(BaseModel))
                {
                    continue;
                }

                sqlExpressionString += $"[{property.Name}],";
                parameterName.Add($"{property.Name}");
            }
            sqlExpressionString = sqlExpressionString.Remove(sqlExpressionString.Length - 1);

            sqlExpressionString += ") VALUES (";

            foreach (var property in _properties)
            {
                if (property.Name == "Id" || property.PropertyType.BaseType == typeof(BaseModel))
                {
                    continue;
                }

                var propValue = property.GetValue(obj);

                sqlExpressionString += $"@{property.Name},";

            }
            sqlExpressionString = sqlExpressionString.Remove(sqlExpressionString.Length - 1);
            sqlExpressionString += ");";

            var sqlCommand = new SqlCommand(sqlExpressionString, _connection);

            int i = 0;
            foreach (var property in _properties)
            {
                if (property.Name == "Id" || property.PropertyType.BaseType == typeof(BaseModel))
                {
                    continue;
                }

                if (property.PropertyType == typeof(DateTime))
                {
                    sqlCommand.Parameters.AddWithValue($"@{parameterName[i]}", $"{((DateTime)property.GetValue(obj)).ToString("yyyy.MM.dd")}");
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue($"@{parameterName[i]}", $"{property.GetValue(obj)}");
                }

                i++;
            }

            try
            {
                _connection.Open();
                sqlCommand.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception)
            {
                throw new Exception("Sql query error.");
            }
        }

        /// <summary>
        /// Method update object to database.
        /// </summary>
        /// <param name="id">Id object.</param>
        /// <param name="obj">Object to update to database.</param>
        public void Update(int id, T obj)
        {
            string sqlExpressionString = $"UPDATE {_tableName} SET ";

            foreach (var property in _properties)
            {
                if (property.Name == "Id" || property.PropertyType.BaseType == typeof(BaseModel))
                {
                    continue;
                }

                sqlExpressionString += $"{property.Name} = @{property.Name},";
            }

            sqlExpressionString = sqlExpressionString.Remove(sqlExpressionString.Length - 1);

            sqlExpressionString += $" WHERE Id = @Id;";
            var sqlCommand = new SqlCommand(sqlExpressionString, _connection);

            foreach (var property in _properties)
            {
                if (property.Name == "Id" || property.PropertyType.BaseType == typeof(BaseModel))
                {
                    continue;
                }

                if (property.PropertyType == typeof(DateTime))
                {
                    sqlCommand.Parameters.AddWithValue($"@{property.Name}", $"{((DateTime)property.GetValue(obj)).ToString("yyyy.MM.dd")}");
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue($"@{property.Name}", $"{property.GetValue(obj)}");
                }
            }

            sqlCommand.Parameters.AddWithValue($"_tableName", _tableName);
            sqlCommand.Parameters.AddWithValue("@Id", id);
            try
            {
                _connection.Open();
                sqlCommand.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception)
            {
                throw new Exception("Sql query error.");
            }
        }

        /// <summary>
        /// Method delete object from database.
        /// </summary>
        /// <param name="id">Id object.</param>
        public void Delete(int id)
        {
            string sqlExpressionString = $"DELETE FROM {_tableName} WHERE Id = @Id ;";

            var sqlCommand = new SqlCommand(sqlExpressionString, _connection);
            sqlCommand.Parameters.AddWithValue($"{_tableName}", _tableName);
            sqlCommand.Parameters.AddWithValue("@Id", id);
            try
            {
                _connection.Open();
                sqlCommand.ExecuteNonQuery();
                _connection.Close();
            }
            catch (Exception)
            {
                throw new Exception("Sql query error.");
            }
        }
    }
}
