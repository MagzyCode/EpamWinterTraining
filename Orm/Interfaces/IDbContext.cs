using System;
using System.Collections.Generic;
using System.Text;

namespace Orm.Interfaces
{
    /// <summary>
    /// Interface describes the !DbContext.
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// The property stores information about database connection string.
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
