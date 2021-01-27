using Orm.Creators;
using Students.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Objects
{
    /// <summary>
    /// Class describes the EducationalSubject.
    /// </summary>
    public class EducationalSubject : BaseModel, IEducationalSubject
    {
        /// <summary>
        /// The constructor initializes the EducationalSubject object.
        /// </summary>
        /// <param name="subjectName">Educational subject name.</param>
        /// <param name="subjectType">Educational subject type.</param>
        public EducationalSubject(string subjectName, string subjectType)
        {
            SubjectName = subjectName;
            SubjectType = subjectType;
        }

        /// <summary>
        /// The empty constructor initializes the EducationalSubject object for fabric method.
        /// </summary>
        public EducationalSubject()
        {
        }

        /// <summary>
        /// The property stores information about SubjectName.
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// The property stores information about SubjectType.
        /// </summary>
        public string SubjectType { get; set; }


        /// <summary>
        /// The method returns information about the object in string form.
        /// </summary>
        /// <returns>Information about the object.</returns>
        public override string ToString()
        {
            return $"Name: {SubjectName}\t Type:{SubjectType}";
        }

        /// <summary>
        /// Method equals two objects.
        /// </summary>
        /// <param name="obj">Equals object.</param>
        /// <returns>Returns the result of the comparison.</returns>
        public override bool Equals(object obj) => obj is EducationalSubject subject &&
                   SubjectName == subject.SubjectName &&
                   SubjectType == subject.SubjectType;

        /// <summary>
        /// The method gets the hash code of the object.
        /// </summary>
        /// <returns>Returns the hash code of the object.</returns>
        public override int GetHashCode() => HashCode.Combine(SubjectName, SubjectType);
    }
}
