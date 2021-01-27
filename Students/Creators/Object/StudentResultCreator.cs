using Orm.Creators;
using Orm.Interfaces;
using Students.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Creators.Object
{
    /// <summary>
    /// Class describes the StudentResultCreator.
    /// </summary>
    public class StudentResultCreator : FabricBaseModel, IFabricBaseModel
    {
        /// <summary>
        /// Method create StudentResult object.
        /// </summary>
        /// <returns>StudentResult object.</returns>
        public override BaseModel Create()
        {
            return new StudentResult();
        }
    }
}
