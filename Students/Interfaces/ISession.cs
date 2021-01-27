using Students.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Interfaces
{
    /// <summary>
    /// Interface describes the ISession.
    /// </summary>
    public interface ISession
    {
        /// <summary>
        /// The property stores information about GroupId.
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// The property stores information about Group object.
        /// </summary>
        public Group Group { get; set; }

        /// <summary>
        /// The property stores information about SessionNumber.
        /// </summary>
        public int SessionNumber { get; set; }
    }
}
