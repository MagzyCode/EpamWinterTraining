using Orm.Creators;
using Orm.Interfaces;
using Students.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Creators.Object
{
    /// <summary>
    /// Class describes the GroupCreator.
    /// </summary>
    public class GroupCreator : FabricBaseModel, IFabricBaseModel
    {
        /// <summary>
        /// Method create GroupCreator object.
        /// </summary>
        /// <returns>GroupCreator object.</returns>
        public override BaseModel Create()
        {
            return new Group();
        }
    }
}
