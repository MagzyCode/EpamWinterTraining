using Students.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Interfaces
{
    /// <summary>
    /// Interface describes the ISessionEducationalSubject.
    /// </summary>
    public interface ISessionEducationalSubject
    {
        /// <summary>
        /// The property stores information about EducationalSubjectId.
        /// </summary>
        public int EducationalSubjectId { get; set; }

        /// <summary>
        /// The property stores information about EducationalSubject object.
        /// </summary>
        public EducationalSubject EducationalSubject { get; set; }

        /// <summary>
        /// The property stores information about Date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The property stores information about SessionId.
        /// </summary>
        public int SessionId { get; set; }

        /// <summary>
        /// The property stores information about Session object.
        /// </summary>
        public Session Session { get; set; }
    }
}
