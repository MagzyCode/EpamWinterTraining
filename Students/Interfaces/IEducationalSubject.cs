using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Interfaces
{
    /// <summary>
    /// Interface describes the IEducationalSubject.
    /// </summary>
    public interface IEducationalSubject
    {
        /// <summary>
        /// The property stores information about SubjectName.
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// The property stores information about SubjectType.
        /// </summary>
        public string SubjectType { get; set; }
    }
}
