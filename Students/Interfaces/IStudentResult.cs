using Students.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Interfaces
{
    /// <summary>
    /// Interface describes the IStudentResult.
    /// </summary>
    public interface IStudentResult
    {
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
    }
}
