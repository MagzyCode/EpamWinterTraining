using Orm.Creators;
using Orm.Interfaces;
using Students.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Creators.Object
{
    /// <summary>
    /// Class describes the SessionCreator.
    /// </summary>
    public class SessionCreator : FabricBaseModel, IFabricBaseModel
    {
        /// <summary>
        /// Method create Session object.
        /// </summary>
        /// <returns>Session object.</returns>
        public override BaseModel Create()
        {
            return new Session();
        }
    }
}
