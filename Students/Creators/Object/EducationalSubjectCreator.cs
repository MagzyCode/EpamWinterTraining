using Orm.Creators;
using Orm.Interfaces;
using Students.Objects;

namespace Students.Creators.Object
{
    /// <summary>
    /// Class describes the EducationalSubjectCreator.
    /// </summary>
    public class EducationalSubjectCreator : FabricBaseModel, IFabricBaseModel
    {
        /// <summary>
        /// Method create EducationalSubject object.
        /// </summary>
        /// <returns>EducationalSubject object.</returns>
        public override BaseModel Create()
        {
            return new EducationalSubject();
        }
    }
}
