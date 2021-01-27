using Orm.Creators;
using Orm.Interfaces;
using Students.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Creators.Object
{
    /// <summary>
    /// Class describes the SessionEducationalSubjectCreator.
    /// </summary>
    public class SessionEducationalSubjectCreator : FabricBaseModel, IFabricBaseModel
    {
        /// <summary>
        /// Method create SessionEducationalSubject object.
        /// </summary>
        /// <returns>SessionEducationalSubject object.</returns>
        public override BaseModel Create()
        {
            return new SessionEducationalSubject();
        }
    }
}
