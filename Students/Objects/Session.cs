using Orm.Creators;
using Students.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Objects
{
    /// <summary>
    /// Class describes the Session.
    /// </summary>
    public class Session : BaseModel, ISession
    {
        /// <summary>
        /// The constructor initializes the Session object.
        /// </summary>
        /// <param name="sessionNumber">Session number.</param>
        /// <param name="groupId">Group id.</param>
        public Session(int sessionNumber, int groupId)
        {
            SessionNumber = sessionNumber;
            GroupId = groupId;
        }

        /// <summary>
        /// The empty constructor initializes the Session object for fabric method.
        /// </summary>
        public Session()
        {
        }

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

        /// <summary>
        /// The method returns information about the object in string form.
        /// </summary>
        /// <returns>Information about the object.</returns>
        public override string ToString() => $"Session Number: {SessionNumber}";

        /// <summary>
        /// Method equals two objects.
        /// </summary>
        /// <param name="obj">Equals object.</param>
        /// <returns>Returns the result of the comparison.</returns>
        public override bool Equals(object obj) => obj is Session session &&
                   GroupId == session.GroupId &&
                   SessionNumber == session.SessionNumber;

        /// <summary>
        /// The method gets the hash code of the object.
        /// </summary>
        /// <returns>Returns the hash code of the object.</returns>
        public override int GetHashCode() => HashCode.Combine(GroupId, SessionNumber);
    }
}
