using Orm.Creators;
using Orm.Interfaces;
using Students.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Creators.Object
{
    /// <summary>
    /// Class describes the StudentCreator.
    /// </summary>
    public class StudentCreator : FabricBaseModel, IFabricBaseModel
    {
        /// <summary>
        /// Method create Student object.
        /// </summary>
        /// <returns>Student object.</returns>
        public override BaseModel Create()
        {
            return new Student();
        }
    }
}
