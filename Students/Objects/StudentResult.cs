using Orm.Creators;
using Students.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Objects
{
    /// <summary>
    /// Class describes the StudentResult.
    /// </summary>
    public class StudentResult : BaseModel, IStudentResult
    {
        /// <summary>
        /// The constructor initializes the StudentResult object.
        /// </summary>
        /// <param name="mark">Mark for exam.</param>
        /// <param name="studentId">Student id.</param>
        /// <param name="sessionEducationalSubjectId">sessionEducationalSubject Id.</param>
        public StudentResult(string mark, int studentId, int sessionEducationalSubjectId)
        {
            Mark = mark;
            StudentId = studentId;
            SessionEducationalSubjectId = sessionEducationalSubjectId;
        }


        /// <summary>
        /// The empty constructor initializes the StudentResult object for fabric method.
        /// </summary>
        public StudentResult()
        {
        }

        /// <summary>
        /// The property stores information about Student object.
        /// </summary>
        public Student Student { get; set; }

        /// <summary>
        /// The property stores information about SessionEducationalSubject object.
        /// </summary>
        public SessionEducationalSubject SessionEducationalSubject { get; set; }

        /// <summary>
        /// The property stores information about StudentId.
        /// </summary>
        public int StudentId { get; set; }

        /// <summary>
        /// The property stores information about SessionEducationalSubjectId.
        /// </summary>
        public int SessionEducationalSubjectId { get; set; }

        /// <summary>
        /// The property stores information about Mark.
        /// </summary>
        public string Mark { get; set; }

        /// <summary>
        /// The method returns information about the object in string form.
        /// </summary>
        /// <returns>Information about the object.</returns>
        public override string ToString() => $"StudentId: {StudentId} {SessionEducationalSubject}\t Assesment: {Mark}";

        /// <summary>
        /// Method equals two objects.
        /// </summary>
        /// <param name="obj">Equals object.</param>
        /// <returns>Returns the result of the comparison.</returns>
        public override bool Equals(object obj) => obj is StudentResult result &&
                   StudentId == result.StudentId &&
                   SessionEducationalSubjectId == result.SessionEducationalSubjectId &&
                   Mark == result.Mark;

        /// <summary>
        /// The method gets the hash code of the object.
        /// </summary>
        /// <returns>Returns the hash code of the object.</returns>
        public override int GetHashCode() => HashCode.Combine(StudentId, SessionEducationalSubjectId, Mark);
    }
}
